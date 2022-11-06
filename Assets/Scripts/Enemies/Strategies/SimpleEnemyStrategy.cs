using System;
using Controls;
using GamePlayer;
using UnityEngine;
using Weapons;
using Zenject;

namespace Enemies
{
    public class SimpleEnemyStrategy: IEnemyStrategy, ITickable
    {
        private Transform _transform;
        private Player _player;
        private IPathFinding _pathFindingStrategy;
        private WeaponData _weaponData;
        private bool _isShooting;
        
        
        public event Action onShootStart;
        public event Action onShootProgress;
        public event Action onShootStop;
        public Vector3 moveDirection
        {
            get
            {
                if(_player is null)
                    return  Vector3.zero;

                return _pathFindingStrategy.GetDir(
                    _transform.position, 
                    _player.transform.position);
            }
        }
        public Vector3 shootDirection { get; private set; }

        private bool isShooting
        {
            set
            {
                if (_isShooting && value)
                    onShootProgress?.Invoke();
                if (!_isShooting && value)
                    onShootStart?.Invoke();
                if (_isShooting && !value)
                    onShootStop?.Invoke();

                _isShooting = value;
            }
        }
        
        public void Tick()
        {
            if(_player is null)
                return;
            
            shootDirection = moveDirection;
            if (_weaponData.type == WeaponType.Melee)
            {
                isShooting = _weaponData.meleeLength < (_transform.position - _player.transform.position).magnitude;
            }
        }
    }
}