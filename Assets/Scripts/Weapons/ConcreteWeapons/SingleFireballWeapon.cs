using Entities;
using Unity.VisualScripting;
using UnityEngine;
using Weapons.Bullets;
using Zenject;

namespace Weapons
{
    public class SingleFireballWeapon: WeaponWithReloadAndSingleShot
    {
        public const string InjectionID = "Fireballs";
        public new class Factory: PlaceholderFactory<TargetType, WeaponData, SingleFireballWeapon>{}
        
        private readonly Fireball.Pool _bulletPool;
        
        [Inject]
        public SingleFireballWeapon(TargetType targetType, WeaponData data,[Inject(Id = InjectionID)] Fireball.Pool bulletPool) : base(targetType, data)
        {
            _bulletPool = bulletPool;
        }

        protected override void PerformShoot(Vector2 startPos, Vector2 direction)
        {
            _bulletPool.Spawn(new Fireball.FireballReinitializingData() {
                velocity = direction * weaponData.bulletSpeed,
                startPosition = startPos,
                
                damage = weaponData.damage,
                targetType = TargetType.Enemy,
                liveTime = weaponData.bulletLiveTime,
                animatorController = weaponData.fireballAnimation,
                spriteScale = weaponData.spriteScale,
                colliderScale = weaponData.colliderScale,
                
                poolSelf = _bulletPool,
            });
        }
    }
}