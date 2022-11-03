using System;
using Weapons;
using Zenject;

namespace Infrastructure
{
    public class WeaponFactory: IFactory<WeaponData ,Weapon>
    {
        private SingleFireballWeapon.Factory _singleFireballWeaponFactory;

        [Inject]
        public WeaponFactory(SingleFireballWeapon.Factory singleFireballWeaponFactory)
        {
            _singleFireballWeaponFactory = singleFireballWeaponFactory;
        }

        public Weapon Create(WeaponData param)
        {
            return param.type switch
            {
                WeaponType.Hit => null,
                WeaponType.SingleFireBall => _singleFireballWeaponFactory.Create(param),
                _ => throw new ArgumentOutOfRangeException(nameof(param), param, null)
            };
        }
    }
}