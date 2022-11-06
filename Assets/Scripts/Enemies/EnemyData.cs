using Entities;
using UnityEngine;

namespace Enemies
{
    [CreateAssetMenu(fileName = "Enemy", menuName = "Demonic Occupation/Data/Enemy", order = 0)]
    public class EnemyData : ScriptableObject, IMovementData
    {
        [field: SerializeField] public StrategyType strategy { get; private set; }
        [field: SerializeField] public PathFindingType pathFinding { get; private set; }
        [field: SerializeField] public float speed { get; private set; }
    }
}