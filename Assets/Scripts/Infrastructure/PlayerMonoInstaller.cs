using System;
using GamePlayer;
using UnityEngine;
using Weapons;
using Zenject;

namespace Infrastructure
{
    public class PlayerMonoInstaller: MonoInstaller
    {
        [SerializeField] private PlayerData playerData;
        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(Camera.main);
            Container.Bind<PlayerData>().FromInstance(playerData).AsCached();
            Container.Bind<Player>()
                .FromSubContainerResolve()
                .ByNewPrefabResourceInstaller<PlayerInstaller>("Prefabs/Player")
                .WithGameObjectName("Player")
                .AsCached()
                .NonLazy();
        }
    }
}