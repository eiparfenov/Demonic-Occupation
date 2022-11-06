using Controls;
using Enemies;
using GamePlayer;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class EnemyInstaller: Installer<EnemyInstaller>
    {
        public override void InstallBindings()
        {
            EnemyData currentEnemy = Container.Resolve<EnemiesSelector>().nextEnemy;
            
            Container.Bind<Transform>().FromComponentOnRoot().AsSingle();
            Container.BindInterfacesAndSelfTo<EnemyData>()
                .FromInstance(currentEnemy)
                .AsSingle();

            Container.Bind<IPathFinding>().To(currentEnemy.pathFinding.GetPathFindingType()).AsSingle();
            Container.Bind<IControl>().To(currentEnemy.strategy.GetStrategyType());
            Container.Bind<IEnemyStrategy>().To(currentEnemy.strategy.GetStrategyType());

            Container.Bind<Rigidbody2D>().FromComponentOnRoot().AsSingle();
            Container.Bind<CircleCollider2D>().FromComponentOnRoot().AsSingle();
            Container.Bind<EntityMovement>().FromNewComponentOnRoot().AsSingle();
            
            
        }
    }
}