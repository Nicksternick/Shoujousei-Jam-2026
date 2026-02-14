using UnityEngine;

public enum EnemyType
{
    Basic,
    MiniBoss,
    FinalBoss

}

[CreateAssetMenu(fileName = "EnemyData", menuName = "ScriptableObjects/EnemyData")]
public class EnemyData : ScriptableObject
{
    public int health;
    public EnemyType enemySprite;
    public AttackSelectionData attackPool;
}
