using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager Instance;
    [SerializeField] private ProjectileStorage storage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 center = BattleManager.Instance.Arena.Center;
        Vector3 playerPostition = BattleManager.Instance.PlayerPosition;

        Vector3 direction = Random.rotation * Vector3.up;
        direction.z = 0;

        Projectile projectile = storage.GetProjectileFromPool(ProjectileType.Bullet);

        projectile.damage = 10;
        projectile.speed = 0.05f;
        projectile.direction = direction.normalized;
        projectile.turnFactor = 0;

        projectile.transform.position = center;
    }
    
    public void ReturnProjectileToPool(Projectile projectile)
    {
        storage.ReturnProjectileToPool(projectile);
    }
}
