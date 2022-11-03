using System;
using Controls;
using Infrastructure;
using UnityEngine;
using Weapons;
using Zenject;

namespace GamePlayer
{
    public class Player: IDisposable
    {
        
        private readonly Weapon.Factory _weaponFactory;
        private readonly Transform _transform;
        private readonly IControl _control;
        private Weapon _weapon;

        public Player(Weapon.Factory weaponFactory, Transform transform, IControl control, [Inject(Id = "PlayerFirstWeapon")]WeaponData firstWeaponData)
        {
            _weaponFactory = weaponFactory;
            _transform = transform;
            _control = control;

            _weapon = _weaponFactory.Create(firstWeaponData);
            _control.onShoot += ControlOnShoot;
        }

        private void ControlOnShoot(Vector2 direction)
        {
            _weapon.ShootStart(_transform.position, direction);
        }

        public void Dispose()
        {
            _control.onShoot -= ControlOnShoot;
        }
    }
}