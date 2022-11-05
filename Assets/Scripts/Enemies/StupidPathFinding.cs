using UnityEngine;

namespace Enemies
{
    public class StupidPathFinding: IPathFinding
    {
        public Vector2 GetDir(Vector2 currentPlace, Vector2 destination)
        {
            return (destination - currentPlace).normalized;
        }
    }
}