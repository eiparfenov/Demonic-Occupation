using System;
using Controls;
using Entities;
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
        private readonly PlayerData _data;
        private Weapon _weapon;

        public Transform transform => _transform;

        public Player(Weapon.Factory weaponFactory, Transform transform, IControl control, PlayerData playerData)
        {
            _weaponFactory = weaponFactory;
            _transform = transform;
            _control = control;
            _data = playerData;

            _weapon = _weaponFactory.Create(TargetType.Environment | TargetType.Enemy, playerData.firstWeapon);
            
            _control.onShootStart += ControlOnShootStart;
            _control.onShootProgress += ControlOnShootProgress;
            _control.onShootStop += ControlOnShootStop;
        }

        private void ControlOnShootStart()
        {
            _weapon.ShootStart(_transform.position + _control.shootDirection * _data.shootStartDistant, _control.shootDirection);
        }

        private void ControlOnShootProgress()
        {
            _weapon.ShootProgress(_transform.position + _control.shootDirection * _data.shootStartDistant, _control.shootDirection);
        }

        private void ControlOnShootStop()
        {
            _weapon.ShootStop(_transform.position + _control.shootDirection * _data.shootStartDistant, _control.shootDirection);
        }

        public void Dispose()
        {
            _control.onShootStart -= ControlOnShootStart;
            _control.onShootProgress -= ControlOnShootProgress;
            _control.onShootStop -= ControlOnShootStop;
        }
    }
}