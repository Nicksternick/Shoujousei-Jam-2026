using UnityEngine;

public class Delay : Projectile
{
    public override ProjectileType Type => ProjectileType.Delay;
    public int delayCount;
    public override Vector3 Move(Transform transform)
    {
        if (delayCount > 0)
        {
            delayCount--;
            return transform.position;
        }

        Vector3 position = transform.position;

        bool clamped;
        BattleManager.Instance.Arena.ClampToStage(position, out clamped);
        if (clamped) { ProjectileManager.Instance.ReturnProjectileToPool(this); }

        position += direction * speed;

        // Turn Factor
        if (turnFactor != 0)
        {
            direction = Quaternion.Euler(0, 0, turnFactor) * direction;
            direction.z = 0;
        }

        return position;
    }

    public override void OnPlayerHit(BattlePlayerController player)
    {
        player.TakeDamage(damage);
        ProjectileManager.Instance.ReturnProjectileToPool(this);
    }
}
