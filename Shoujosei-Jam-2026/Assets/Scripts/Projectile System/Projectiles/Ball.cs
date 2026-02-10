using UnityEngine;

public class Ball : Projectile
{
    public int decay;
    public override ProjectileType Type => ProjectileType.Ball;

    public override Vector3 Move(Transform transform)
    {
        if (decay == 0) ProjectileManager.Instance.ReturnProjectileToPool(this); ;

        Vector3 position = transform.position;

        position += direction * speed;

        bool clampedX;
        bool clampedY;
        BattleManager.Instance.Arena.ClampToStageX(position, out clampedX);
        BattleManager.Instance.Arena.ClampToStageY(position, out clampedY);

        if (clampedX || clampedY) { decay--; }

        direction.x *= clampedX ? -1 : 1;
        direction.y *= clampedY ? -1 : 1;
        turnFactor *= clampedX || clampedY ? -1 : 1;

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
