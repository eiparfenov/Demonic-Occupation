using Controls;
using Entities;
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
            Container.BindMemoryPool<Fireball, Fireball.Pool>().
                WithId(SingleFireballWeapon.InjectionID).
                FromSubContainerResolve().ByNewPrefabResourceInstaller<FireballInstaller>("Prefabs/Fireball").
                UnderTransformGroup("Fireballs");
        }

        private void InstallWeaponsFactories()
        {
            Container.BindFactory<TargetType, WeaponData , MeleeWeapon, MeleeWeapon.Factory>();
            Container.BindFactory<TargetType, WeaponData , SingleFireballWeapon, SingleFireballWeapon.Factory>();
            Container.BindFactory<TargetType, WeaponData, Weapon, Weapon.Factory>().FromFactory<WeaponFactory>();
        }
        
        private void InstallControls()
        {
            Container.BindInterfacesTo<PCControl>().AsCached();
        }
    }
}