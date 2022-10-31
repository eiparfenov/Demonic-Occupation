using UnityEngine;

namespace Weapons
{
    public class WeaponData: ScriptableObject
    {
        [field:SerializeField] public WeaponType type { get; private set; }
        [field: SerializeField] public float reloadTime { get; private set; }
    }
}