using System;

namespace Entities
{
    [Flags]
    public enum TargetType
    {
        Player = 1, Enemy = 2, Environment = 4
    }
}