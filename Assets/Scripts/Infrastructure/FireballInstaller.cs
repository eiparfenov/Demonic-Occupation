using UnityEngine;
using Weapons.Bullets;
using Zenject;

namespace Infrastructure
{
    public class FireballInstaller: Installer<FireballInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<Rigidbody2D>().FromComponentOnRoot().AsSingle();
            Container.Bind<CircleCollider2D>().FromComponentOnRoot().AsSingle();
            Container.Bind<Animator>().FromComponentInHierarchy().AsSingle();
            Container.Bind<Fireball>().FromNewComponentOnRoot().AsSingle();
        }
    }
}