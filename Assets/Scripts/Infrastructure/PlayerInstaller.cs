using GamePlayer;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class PlayerInstaller: Installer<PlayerInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.Bind<Rigidbody2D>().FromComponentOnRoot().AsSingle();
            Container.Bind<PlayerMovement>().FromNewComponentOnRoot().AsSingle().NonLazy();
            Container.Bind<Player>().AsSingle().NonLazy();
        }
    }
}