using System;
using Entities;
using UnityEngine;
using Zenject;

namespace Weapons
{
    public abstract class Weapon: IDisposable
    {
        public class Factory: PlaceholderFactory<TargetType , WeaponData, Weapon>{}
        protected WeaponData weaponData;
        protected TargetType targetType;

        public void ShootStart(Vector2 startPos, Vector2 direction)
        {
            OnShootStart(startPos, direction);
        }

        public void ShootProgress(Vector2 startPos, Vector2 direction)
        {
            OnShootProgress(startPos, direction);
        }

        public void ShootStop(Vector2 startPos, Vector2 direction)
        {
            OnShootProgress(startPos, direction);
        }
        public virtual void Dispose(){}

        [Inject]
        protected Weapon(TargetType targetType, WeaponData data)
        {
            this.targetType = targetType;
            weaponData = data;
        }

        protected virtual void OnShootStart(Vector2 startPos, Vector2 direction){}
        protected virtual void OnShootProgress(Vector2 startPos, Vector2 direction){}
        protected virtual void OnShootEnd(Vector2 startPos, Vector2 direction){}
    }
}