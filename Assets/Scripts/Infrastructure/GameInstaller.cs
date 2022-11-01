using Controls;
using GamePlayer;
using UnityEngine;
using Weapons;
using Weapons.Bullets;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallControls();
            InstallWeaponsFactories();
            InstallBulletPools();
            InstallPlayer();
        }

        private void InstallBulletPools()
        {
            Container.BindMemoryPool<Bullet, Bullet.Pool>().
                WithId(SingleFireballWeapon.InjectionID).
                FromComponentInNewPrefabResource("Prefabs/Fireball").
                UnderTransformGroup("Fireballs");
        }

        private void InstallWeaponsFactories()
        {
            Container.BindFactory<SingleFireballWeapon, SingleFireballWeapon.Factory>();
            Container.BindFactory<WeaponType, Weapon, Weapon.Factory>().FromFactory<WeaponFactory>();
        }

        private void InstallPlayer()
        {
            Container.Bind<Player>()
                .FromSubContainerResolve()
                .ByNewPrefabResourceInstaller<Player.PlayerInstaller>("Prefabs/Player")
                .WithGameObjectName("Player")
                .AsCached()
                .NonLazy();
        }

        private void InstallControls()
        {
            Container.BindInterfacesTo<PCControl>().AsCached();
        }
    }
}