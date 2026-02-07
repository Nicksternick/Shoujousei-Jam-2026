using UnityEngine;

[System.Serializable]
public struct encounterData
{
    public AttackSelection encounter;
    public Sprite EncounterSprite;
}

[CreateAssetMenu(fileName = "OverWorldEncounter", menuName = "ScriptableObjects/OverworldEncounter")]

public class OverworldEncounterStorage : ScriptableObject
{
   public encounterData encounter;
}
