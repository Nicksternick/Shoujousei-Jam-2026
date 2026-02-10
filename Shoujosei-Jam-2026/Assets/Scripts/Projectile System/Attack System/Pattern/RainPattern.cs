using UnityEngine;

public class RainPattern : AttackPattern
{
    public override void UpdatePattern(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        Wave projectile = ProjectileManager.Instance.GetProjectileFromPool(ProjectileType.Wave) as Wave;

        projectile.damage = damage;
        projectile.speed = speed;
        projectile.direction = spawnNormal;

        projectile.transform.position = spawnPoint;
    }
}
