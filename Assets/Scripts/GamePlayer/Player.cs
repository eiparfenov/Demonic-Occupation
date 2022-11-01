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
        public class PlayerInstaller: Installer<PlayerInstaller>
        {
            public override void InstallBindings()
            {
                Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
                Container.Bind<Player>().AsSingle().NonLazy();
            }
        }
        private Weapon.Factory _weaponFactory;
        private readonly Transform _transform;
        private readonly IControl _control;
        private Weapon _weapon;

        public Player(Weapon.Factory weaponFactory, Transform transform, IControl control)
        {
            _weaponFactory = weaponFactory;
            _transform = transform;
            _control = control;

            _weapon = weaponFactory.Create(WeaponType.SingleFireBall);
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