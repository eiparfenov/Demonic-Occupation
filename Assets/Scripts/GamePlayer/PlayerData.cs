using UnityEngine;
using Weapons;

namespace GamePlayer
{
    [CreateAssetMenu(menuName = "Demonic Occupation/Data/PlayerData", fileName = "PlayerData")]
    public class PlayerData: ScriptableObject
    {
        [field: SerializeField] public WeaponData firstWeapon { get; private set; }
        [field: SerializeField] public float speed { get; private set; }
        [field: SerializeField] public float shootStartDistant { get; private set; }
    }
}