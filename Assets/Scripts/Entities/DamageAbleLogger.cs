using UnityEngine;

namespace Entities
{
    public class DamageAbleLogger: MonoBehaviour, IDamageAble
    {
        [field:SerializeField] public TargetType targetType { get; private set; }
        public void Damage(float damage)
        {
            Debug.unityLogger.Log("DamageAbleLogger.Damage", $"Got {damage} of damage!");
        }
    }
}