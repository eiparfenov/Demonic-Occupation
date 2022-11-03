using Entities;
using UnityEngine;
using Weapons.Bullets;
using Zenject;

namespace Weapons
{
    public class SingleFireballWeapon: WeaponWithReloadAndSingleShot
    {
        public const string InjectionID = "Fireballs";
        public new class Factory: PlaceholderFactory<WeaponData, SingleFireballWeapon>{}
        
        private readonly Bullet.Pool _bulletPool;
        
        [Inject]
        public SingleFireballWeapon(WeaponData data,[Inject(Id = InjectionID)] Bullet.Pool bulletPool) : base(data)
        {
            _bulletPool = bulletPool;
        }

        protected override void PerformShoot(Vector2 startPos, Vector2 direction)
        {
            _bulletPool.Spawn(new Bullet.BulletReinitializingData() {
                damage = 1f,
                startPosition = startPos,
                targetType = TargetType.Enemy,
                velocity = direction,
                poolSelf = _bulletPool
            });
        }
    }
}