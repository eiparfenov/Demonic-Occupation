using System;
using System.Collections.Generic;
using UnityEngine;
using Weapons;
using Zenject;

namespace Infrastructure
{
    public class DataInstaller: ScriptableObjectInstaller
    {
        [Serializable]
        private class WeaponInfo
        {
            [field: SerializeField] public string name { get; private set; }
            [field: SerializeField] public WeaponData weaponData { get; private set; }
        }

        [SerializeField] private List<WeaponInfo> weapons;
        private Dictionary<string, WeaponData> _weapons;
        public override void InstallBindings()
        {
            FormAllWeapons();
            
            BindWeaponData(SingleFireballWeapon.InjectionID);
        }

        private void FormAllWeapons()
        {
            _weapons = new();

            foreach (WeaponInfo weaponInfo in weapons)
                _weapons[weaponInfo.name] = weaponInfo.weaponData;
        }

        private void BindWeaponData(string id)
        {
            Container.Bind<WeaponData>().WithId(id).FromInstance(_weapons[id]);
        }
    }
}