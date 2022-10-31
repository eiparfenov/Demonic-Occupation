using System;
using Weapons;
using Zenject;

namespace Infrastructure
{
    public class WeaponFactory: IFactory<WeaponType ,Weapon>
    {
        private SingleFireballWeapon.Factory _singleFireballWeaponFactory;

        [Inject]
        public WeaponFactory(SingleFireballWeapon.Factory singleFireballWeaponFactory)
        {
            _singleFireballWeaponFactory = singleFireballWeaponFactory;
        }

        public Weapon Create(WeaponType param)
        {
            return param switch
            {
                WeaponType.Hit => null,
                WeaponType.SingleFireBall => _singleFireballWeaponFactory.Create(),
                _ => throw new ArgumentOutOfRangeException(nameof(param), param, null)
            };
        }
    }
}