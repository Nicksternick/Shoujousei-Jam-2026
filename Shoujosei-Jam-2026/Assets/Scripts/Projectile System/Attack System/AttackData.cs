using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "ScriptableObjects/AttackData")]
public class AttackData : ScriptableObject
{
    public int Damage;
    public float Speed;
    public AttackPattern Pattern;
    public ArenaPoints[] AttackPoints;
    public bool TriggerAtAllPoints;
    public int MinPoints;
    public int MaxPoints;

    public float Offset;

    public int AttackLength;
    public int AttackRate;
}
