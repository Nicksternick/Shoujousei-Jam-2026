using UnityEditor.SceneManagement;
using UnityEngine;

public class BulletLaunch : AttackPattern
{
    public override void UpdatePattern(Vector3 spawnPoint)
    {
        Vector3 direction = BattleManager.Instance.PlayerPosition - spawnPoint;

        Bullet projectile = ProjectileManager.Instance.GetProjectileFromPool(ProjectileType.Bullet) as Bullet;

        projectile.damage = damage;
        projectile.speed = speed;
        projectile.direction = direction.normalized;
        projectile.turnFactor = 0;

        projectile.transform.position = spawnPoint;
    }
}
