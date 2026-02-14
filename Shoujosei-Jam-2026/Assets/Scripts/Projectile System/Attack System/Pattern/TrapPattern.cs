using UnityEngine;

public class TrapPattern : AttackPattern
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private float turnFactor;
    [SerializeField] private int delayCount;
    [SerializeField] private float offset;

    public override void UpdatePattern(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        // Degrees between each bullet
        float step = 360f / numberOfBullets;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float angleDeg = (step * i);
            float angleRad = angleDeg * Mathf.Deg2Rad;

            Vector3 direction = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad), 0f).normalized;

            Delay projectile = ProjectileManager.Instance.GetProjectileFromPool(ProjectileType.Delay) as Delay;

            projectile.transform.position = spawnPoint + direction * offset;
            projectile.damage = damage;
            projectile.speed = speed;
            projectile.direction = (BattleManager.Instance.Arena.Center - projectile.transform.position).normalized;
            projectile.turnFactor = turnFactor;
            projectile.delayCount = delayCount;
        }
    }
}
