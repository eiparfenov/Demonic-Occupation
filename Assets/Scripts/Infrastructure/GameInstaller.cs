using Weapons;
using Weapons.Bullets;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller: MonoInstaller
    {
        public override void InstallBindings()
        {
            
        }

        private void InstallBulletPools()
        {
            Container.BindMemoryPool<Bullet, Bullet.Pool>().
                WithId("Fireballs").
                FromNewComponentOnNewPrefabResource("Prefabs/Fireball").
                UnderTransformGroup("Fireballs");
        }

        private void InstallWeaponsFactories()
        {
            Container.BindFactory<SingleFireballWeapon, SingleFireballWeapon.Factory>();
            Container.BindIFactory<Weapon, WeaponFactory>();
        }
    }
}