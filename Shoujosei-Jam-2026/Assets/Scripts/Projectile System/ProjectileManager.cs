using System;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager Instance;
    [SerializeField] private ProjectileWarningIcon warningIcon;
    [SerializeField] private ProjectileStorage storage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instance = this;
    }

    public Projectile GetProjectileFromPool(ProjectileType type)
    {
        return storage.GetProjectileFromPool(type);
    }
    
    public void ReturnProjectileToPool(Projectile projectile)
    {
        storage.ReturnProjectileToPool(projectile);
    }

    public void SpawnHeadsUpWarning(Vector3 position, Action function, int displayTime = (60))
    {
        ProjectileWarningIcon icon = Instantiate(warningIcon);
        icon.transform.position = position;
        icon.DisplayTime = displayTime;
        icon.OnComplete = function;
    }
}
