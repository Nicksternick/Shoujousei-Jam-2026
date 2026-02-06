using UnityEngine;

public class Dart : Projectile
{
    public float decay;
    private Vector3 target;
    public override ProjectileType Type => ProjectileType.Dart;

    private void Start()
    {
        direction = (BattleManager.Instance.PlayerPosition - gameObject.transform.position).normalized;
    }

    public override Vector3 Move(Transform transform)
    {
        if (decay <= 0) ProjectileManager.Instance.ReturnProjectileToPool(this); ;
        decay--;

        Vector3 position = transform.position;

        bool clamped;
        BattleManager.Instance.Arena.ClampToStage(position, out clamped);
        if (clamped) { ProjectileManager.Instance.ReturnProjectileToPool(this); ; }

        target = BattleManager.Instance.PlayerPosition;

        position += direction * speed;

        Vector3 toTarget = (target - position).normalized;
        toTarget.z = 0f;

        if (turnFactor != 0)
        {
            direction = Vector3.RotateTowards(
                direction,
                toTarget,
                turnFactor * Time.fixedDeltaTime,
                0f).normalized;
        }

        return position;
    }

    public override void OnPlayerHit(BattlePlayerController player)
    {
        player.TakeDamage(damage);
        ProjectileManager.Instance.ReturnProjectileToPool(this);
    }
}
