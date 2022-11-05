using System;
using Entities;
using Weapons;
using Zenject;

namespace Infrastructure
{
    public class WeaponFactory: IFactory<TargetType, WeaponData ,Weapon>
    {
        private SingleFireballWeapon.Factory _singleFireballWeaponFactory;
        private MeleeWeapon.Factory _meleeWeaponFactory;

        [Inject]
        public WeaponFactory(SingleFireballWeapon.Factory singleFireballWeaponFactory, MeleeWeapon.Factory meleeWeaponFactory)
        {
            _singleFireballWeaponFactory = singleFireballWeaponFactory;
            _meleeWeaponFactory = meleeWeaponFactory;
        }

        public Weapon Create(TargetType targetType ,WeaponData data)
        {
            return data.type switch
            {
                WeaponType.Melee => _meleeWeaponFactory.Create(targetType, data),
                WeaponType.SingleFireball => _singleFireballWeaponFactory.Create(targetType, data),
                _ => throw new ArgumentOutOfRangeException(nameof(data), data, null)
            };
        }
    }
}