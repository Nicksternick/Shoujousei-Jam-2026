using UnityEngine;
using UnityEngine.Rendering;

public class MinionPattern : AttackPattern
{
    [SerializeField] private int decay;
    [SerializeField] private float turnFactor;

    public override void UpdatePattern(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        Vector3 direction = (BattleManager.Instance.PlayerPosition - spawnPoint).normalized;

        Dart projectile = ProjectileManager.Instance.GetProjectileFromPool(ProjectileType.Dart) as Dart;

        projectile.damage = damage;
        projectile.speed = speed;
        projectile.direction = direction.normalized;
        projectile.turnFactor = turnFactor;

        projectile.decay = decay;

        projectile.transform.position = spawnPoint;
    }
}
