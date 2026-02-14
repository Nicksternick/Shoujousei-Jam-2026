using UnityEngine;

public class SpiralPattern : AttackPattern
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private float turnFactor;

    public override void UpdatePattern(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        // Degrees between each bullet
        float step = 360f / numberOfBullets;

        float angleDeg = (step * (time % numberOfBullets));
        float angleRad = angleDeg * Mathf.Deg2Rad;

        Vector3 direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f);

        Bullet projectile = ProjectileManager.Instance.GetProjectileFromPool(ProjectileType.Bullet) as Bullet;

        projectile.damage = damage;
        projectile.speed = speed;
        projectile.direction = direction.normalized;
        projectile.turnFactor = turnFactor;

        projectile.transform.position = spawnPoint;
    }
}
