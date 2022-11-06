using UnityEngine;

namespace Enemies
{
    public interface IPathFinding
    {
        Vector2 GetDir(Vector2 currentPlace, Vector2 destination);
    }
}