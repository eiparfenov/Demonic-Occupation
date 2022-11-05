using System.Linq;
using Entities;
using UnityEngine;
using Zenject;

namespace Weapons
{
    public class MeleeWeapon: WeaponWithReloadAndSingleShot
    {
        public class Factory: PlaceholderFactory<TargetType, WeaponData, MeleeWeapon>{}

        public MeleeWeapon(TargetType targetType, WeaponData data) : base(targetType, data) { }

        protected override void PerformShoot(Vector2 startPos, Vector2 direction)
        {
            var damageAbles = 
                Physics2D.RaycastAll(startPos, direction.normalized, direction.magnitude)
                .Select(x => x.collider.GetComponent<IDamageAble>())
                .Where(x => x != null && (x.targetType & TargetType.Enemy) != 0);

            foreach (IDamageAble damageAble in damageAbles)
            {
                damageAble.Damage(weaponData.damage);
            }
        }
    }
}