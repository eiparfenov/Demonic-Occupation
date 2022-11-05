using GamePlayer;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class PlayerInstaller: Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PlayerData>().FromResource("Data/PlayerData").AsSingle();
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.Bind<Rigidbody2D>().FromComponentOnRoot().AsSingle();
            Container.Bind<EntityMovement>().FromNewComponentOnRoot().AsSingle().NonLazy();
            Container.Bind<Player>().AsSingle().NonLazy();
        }
    }
}