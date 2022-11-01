using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Weapons
{
    public abstract class WeaponWithReloadAndSingleShot: Weapon
    {
        private readonly CancellationTokenSource _objectIsAlive = new CancellationTokenSource();
        /// <summary>
        /// Value in range 0..1, that represents current reload state
        /// </summary>
        protected float reload;

        protected WeaponWithReloadAndSingleShot(WeaponData data): base(data)
        {
            reload = 1f;
            ProcessReloading(_objectIsAlive.Token);
        }
        
        protected override void OnShootStart(Vector2 startPos, Vector2 direction)
        {
            if(Math.Abs(reload - 1f) < .01f)
            {
                reload = 0f;
                PerformShoot(startPos, direction);
            }
        }

        protected override void OnShootProgress(Vector2 startPos, Vector2 direction)
        {
            if (Math.Abs(reload - 1f) < .01f)
            {
                reload = 0f;
                PerformShoot(startPos, direction);
            }
        }

        private async void ProcessReloading(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                await UniTask.Yield(PlayerLoopTiming.Update, token);
                reload += Time.deltaTime / weaponData.reloadTime;
                reload = Mathf.Clamp01(reload);
            }
        }

        public override void Dispose()
        {
            _objectIsAlive.Cancel();
            _objectIsAlive.Dispose();
        }

        protected abstract void PerformShoot(Vector2 startPos, Vector2 direction);
    }
}