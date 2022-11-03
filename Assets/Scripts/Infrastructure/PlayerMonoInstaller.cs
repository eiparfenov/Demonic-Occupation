using System;
using GamePlayer;
using UnityEngine;
using Weapons;
using Zenject;

namespace Infrastructure
{
    public class PlayerMonoInstaller: MonoInstaller
    {
        [SerializeField] private WeaponData firstWeapon;
        public override void InstallBindings()
        {
            Container.Bind<WeaponData>().WithId("PlayerFirstWeapon").FromInstance(firstWeapon).AsCached();
            Container.Bind<Player>()
                .FromSubContainerResolve()
                .ByNewPrefabResourceInstaller<PlayerInstaller>("Prefabs/Player")
                .WithGameObjectName("Player")
                .AsCached()
                .NonLazy();
            //Container.Unbind<WeaponData>();
        }
    }
}