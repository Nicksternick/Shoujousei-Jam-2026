using System;
using System.Collections.Generic;
using UnityEngine;

public enum ProjectileType
{
    None = -1,
    Bullet,
    Ball,
    Dart,
    Wave,
    Delay
}

public class ProjectileStorage : MonoBehaviour
{
    [SerializeField] private int defaultCapacity = 50;
    [SerializeField] private int poolMax = 1000;
    [SerializeField] private Projectile[] projectiles;
    private Dictionary<ProjectileType, Projectile> projectileDict = new Dictionary<ProjectileType, Projectile>();
    private GenericPool<Bullet> bulletPool;
    private GenericPool<Ball> ballPool;
    private GenericPool<Dart> dartPool;
    private GenericPool<Wave> wavePool;
    private GenericPool<Delay> delayPool;

    private void Awake()
    {
        projectileDict = new Dictionary<ProjectileType, Projectile>();

        foreach (Projectile projectile in projectiles)
        {
            projectileDict.Add(projectile.Type, projectile);
            RegisterProjectilePool(projectile);
        }
    }

    private void RegisterProjectilePool(Projectile projectile)
    {
        switch (projectile.Type)
        {
            case ProjectileType.Bullet:
                bulletPool = new GenericPool<Bullet>((Bullet)projectile, defaultCapacity, poolMax);
                break;
            case ProjectileType.Ball:
                ballPool = new GenericPool<Ball>((Ball)projectile, defaultCapacity, poolMax);
                break;
            case ProjectileType.Dart:
                dartPool = new GenericPool<Dart>((Dart)projectile, defaultCapacity, poolMax);
                break;
            case ProjectileType.Wave:
                wavePool = new GenericPool<Wave>((Wave)projectile, defaultCapacity, poolMax);
                break;
            case ProjectileType.Delay:
                delayPool = new GenericPool<Delay>((Delay)projectile, defaultCapacity, poolMax);
                break;
        }
    }

    public Projectile GetProjectileFromPool(ProjectileType type)
    {
        switch (type)
        {
            case ProjectileType.Bullet:
                return bulletPool.GetFromPool();
            case ProjectileType.Ball:
                return ballPool.GetFromPool();
            case ProjectileType.Dart:
                return dartPool.GetFromPool();
            case ProjectileType.Wave:
                return wavePool.GetFromPool();
            case ProjectileType.Delay:
                return delayPool.GetFromPool();
            default:
                Debug.LogError($"{type.ToString()} does not have a projectile pool");
                return null;
        }
    }

    public void ReturnProjectileToPool(Projectile projectile)
    {
        switch (projectile.Type)
        {
            case ProjectileType.Bullet:
                bulletPool.ReturnToPool((Bullet)projectile);
                break;
            case ProjectileType.Ball:
                ballPool.ReturnToPool((Ball)projectile);
                break;
            case ProjectileType.Dart:
                dartPool.ReturnToPool((Dart)projectile);
                break;
            case ProjectileType.Wave:
                wavePool.ReturnToPool((Wave)projectile);
                break;
            case ProjectileType.Delay:
                delayPool.ReturnToPool((Delay)projectile);
                break;
        }
    }
}
