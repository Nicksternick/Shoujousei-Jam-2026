using UnityEngine;

public class BouncePattern : AttackPattern
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private int decay;

    public override void UpdatePattern(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        // Degrees between each bullet
        float step = 360f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float angleDeg = (step * i);
            float angleRad = angleDeg * Mathf.Deg2Rad;

            Vector3 direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f);

            Ball projectile = ProjectileManager.Instance.GetProjectileFromPool(ProjectileType.Ball) as Ball;

            projectile.damage = damage;
            projectile.speed = speed;
            projectile.direction = direction.normalized;
            projectile.turnFactor = 0;

            projectile.decay = decay;

            projectile.transform.position = spawnPoint;
        }
    }
}
