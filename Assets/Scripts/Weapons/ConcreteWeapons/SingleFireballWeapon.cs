using Weapons.Bullets;
using Zenject;

namespace Weapons
{
    public class SingleFireballWeapon: WeaponWithReloadAndSingleShot
    {
        public class Factory: PlaceholderFactory<SingleFireballWeapon>{}
        
        private Bullet.Pool _bulletPool;
        [Inject]
        public SingleFireballWeapon(WeaponData data,[Inject(Id = "Fireballs")] Bullet.Pool bulletPool) : base(data)
        {
            _bulletPool = bulletPool;
        }

        protected override void PerformShoot()
        {
            
        }
    }
}