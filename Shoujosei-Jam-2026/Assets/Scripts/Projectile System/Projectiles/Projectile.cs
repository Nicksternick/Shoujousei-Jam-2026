using System;
using UnityEngine;

public abstract class Projectile : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    public float turnFactor = 1;
    public int damage;
    public virtual ProjectileType Type => ProjectileType.None;
    public Type ClassType => GetType();
    private void FixedUpdate()
    {
        transform.position = Move(transform);
    }
    public abstract Vector3 Move(Transform transform);
    public abstract void OnPlayerHit(BattlePlayerController player);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BattlePlayerController player = collision.GetComponent<BattlePlayerController>();
        if (player)
        {
            OnPlayerHit(player);
        }
    }
}
