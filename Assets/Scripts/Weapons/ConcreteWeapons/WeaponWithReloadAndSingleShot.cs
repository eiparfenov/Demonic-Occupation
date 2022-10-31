using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Weapons
{
    public abstract class WeaponWithReloadAndSingleShot: Weapon
    {
        private CancellationTokenSource _objectIsAlive = new CancellationTokenSource();
        /// <summary>
        /// Value in range 0..1, that represents current reload state
        /// </summary>
        protected float reload;

        protected WeaponWithReloadAndSingleShot(WeaponData data): base(data)
        {
            reload = 1f;
            ProcessReloading(_objectIsAlive.Token);
        }
        
        protected override void OnShootStart()
        {
            if(Math.Abs(reload - 1f) < .01f)
            {
                reload = 0f;
                PerformShoot();
            }
        }

        protected override void OnShootProgress()
        {
            if (Math.Abs(reload - 1f) < .01f)
            {
                reload = 0f;
                PerformShoot();
            }
        }

        private async void ProcessReloading(CancellationToken token)
        {
            while (token.IsCancellationRequested)
            {
                await UniTask.Yield(PlayerLoopTiming.Update);
                reload += Time.deltaTime / weaponData.reloadTime;
                reload = Mathf.Clamp01(reload);
            }
        }

        public override void Dispose()
        {
            _objectIsAlive.Cancel();
            _objectIsAlive.Dispose();
        }
    }
}