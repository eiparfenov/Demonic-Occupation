using System;
using Zenject;

namespace Weapons
{
    public abstract class Weapon: IDisposable
    {
        protected WeaponData weaponData;

        public void ShootStart(){}
        public void ShootProgress(){}
        public void ShootStop(){}
        public virtual void Dispose(){}

        [Inject]
        protected Weapon(WeaponData data)
        {
            weaponData = data;
        }

        protected virtual void OnShootStart(){}
        protected virtual void OnShootProgress(){}
        protected virtual void OnShootEnd(){}
        
        protected virtual void PerformShoot(){}
    }
}