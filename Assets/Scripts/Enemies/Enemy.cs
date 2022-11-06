using GamePlayer;
using Zenject;

namespace Enemies
{
    public class Enemy: ITickable
    {
        private IEnemyStrategy _strategy;
        private EntityMovement _movement;

        public void Tick()
        {
            
        }
    }
}