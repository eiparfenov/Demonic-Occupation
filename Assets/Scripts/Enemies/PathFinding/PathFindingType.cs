using System;

namespace Enemies
{
    public enum PathFindingType
    {
        Simple
    }

    public static class PathFindingTypeUtils
    {
        public static Type GetPathFindingType(this PathFindingType type)
        {
            return type switch
            {
                PathFindingType.Simple => typeof(StupidPathFinding),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}