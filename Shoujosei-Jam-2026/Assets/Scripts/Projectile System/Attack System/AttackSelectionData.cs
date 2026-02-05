using UnityEngine;

[System.Serializable]
public struct AttackSelection
{
    public AttackData AttackData;
    public int ActivationWeight;
}

[CreateAssetMenu(fileName = "AttackSelectionData", menuName = "ScriptableObjects/AttackSelectionData")]
public class AttackSelectionData : ScriptableObject
{
    public AttackSelection[] AttackSelection;
}
