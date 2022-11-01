using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(menuName = "Demonic Occupation/Data/Weapon", fileName = "Weapon")]
    public class WeaponData: ScriptableObject
    {
        [field:SerializeField] public WeaponType type { get; private set; }
        [field: SerializeField] public float reloadTime { get; private set; }
    }
}