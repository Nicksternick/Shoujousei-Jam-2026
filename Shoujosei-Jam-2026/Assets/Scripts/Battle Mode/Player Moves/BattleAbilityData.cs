using UnityEngine;

[CreateAssetMenu(fileName = "BattleAbilityData", menuName = "ScriptableObjects/BattleAbilityData")]
public class BattleAbilityData : ScriptableObject
{
    public BattleAbility[] abilities;
}
