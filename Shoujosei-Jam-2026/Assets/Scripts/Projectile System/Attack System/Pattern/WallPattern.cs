using UnityEngine;

public class WallPattern : AttackPattern
{
    [SerializeField] private int numberOfBullets;
    private float xExtents;
    private float yExtents;
    

    public override void UpdatePattern(Vector3 spawnPoint, Vector3 spawnNormal)
    {
        float step;
        if (spawnNormal.x == 0)
        {
            xExtents = BattleManager.Instance.Arena.MaxX - BattleManager.Instance.Arena.MinX;
            step = xExtents / numberOfBullets;
        }
        else
        {
            yExtents = BattleManager.Instance.Arena.MaxY - BattleManager.Instance.Arena.MinY;
            step = yExtents / numberOfBullets;
        }
            
        for (int i = 0; i < numberOfBullets + 1; i++)
        {
            Vector3 position = spawnPoint;
            if (spawnNormal.x == 0)
            {
                position.x = BattleManager.Instance.Arena.MinX + (step * i);
            }
            else
            {
                position.y = BattleManager.Instance.Arena.MinY + (step * i);
            }

            Bullet projectile = ProjectileManager.Instance.GetProjectileFromPool(ProjectileType.Bullet) as Bullet;

            projectile.damage = damage;
            projectile.speed = speed;
            projectile.direction = spawnNormal.normalized;
            projectile.turnFactor = 0;

            projectile.transform.position = position;
        }
    }
}
