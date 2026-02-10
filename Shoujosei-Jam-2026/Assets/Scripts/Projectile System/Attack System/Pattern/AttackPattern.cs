using UnityEngine;

public abstract class AttackPattern : MonoBehaviour
{
    protected int time = 0;
    protected int damage = 0;
    protected float speed = 0;
    public void SetDamage(int damage) { this.damage = damage; }
    public void SetSpeed(float speed) { this.speed = speed; }
    public void TickPattern() { time++; }
    public abstract void UpdatePattern(Vector3 spawnPoint, Vector3 spawnNormal);
}
