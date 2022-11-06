using System;

namespace Enemies
{
    public enum StrategyType
    {
        Simple
    }

    public static class StrategyTypeUtils
    {
        public static Type GetStrategyType(this StrategyType strategyType)
        {
            return strategyType switch
            {
                StrategyType.Simple => typeof(SimpleEnemyStrategy),
                _ => throw new ArgumentOutOfRangeException(nameof(strategyType), strategyType, null)
            };
        }
    }
}