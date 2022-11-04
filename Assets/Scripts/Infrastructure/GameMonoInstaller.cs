using Controls;
using GamePlayer;
using UnityEngine;
using Weapons;
using Weapons.Bullets;
using Zenject;

namespace Infrastructure
{
    public class GameMonoInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallControls();
            InstallWeaponsFactories();
            InstallBulletPools();
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
            Container.BindFactory<WeaponData , SingleFireballWeapon, SingleFireballWeapon.Factory>();
            Container.BindFactory<WeaponData, Weapon, Weapon.Factory>().FromFactory<WeaponFactory>();
        }
        
        private void InstallControls()
        {
            Container.BindInterfacesTo<PCControl>().AsCached();
        }
    }
}