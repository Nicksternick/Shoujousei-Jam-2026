using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : IObjectPool<Projectile>
{
    private Dictionary<ProjectileType, ObjectPool<Projectile>> projectilePools = new Dictionary<ProjectileType, ObjectPool<Projectile>>();

    public int CountInactive => throw new System.NotImplementedException();

    public void RegisterProjectilePool(ProjectileType type, Projectile projectile)
    {
        if (!projectilePools.ContainsKey(type))
        {
            //projectilePools.Add(type, )
        }
    }

    public void Clear()
    {
        throw new System.NotImplementedException();
    }

    public Projectile Get()
    {
        throw new System.NotImplementedException();
    }

    public PooledObject<Projectile> Get(out Projectile v)
    {
        throw new System.NotImplementedException();
    }

    public void Release(Projectile element)
    {
        throw new System.NotImplementedException();
    }

    //private void OnTakeFromPool(Projectile projectile)
    //{
    //    projectile.gameObject.SetActive(true);
    //}

    //private void OnReturnToPool(Projectile projectile)
    //{
    //    if (projectile.gameObject.activeSelf)
    //    {
    //        projectile.gameObject.SetActive(false);
    //    }
    //}

    //private void OnDestroyInstance(Projectile projectile)
    //{
    //    Destroy(projectile.gameObject);
    //}

    //public Projectile GetFromPool(ProjectileType type)
    //{
    //    if (projectilePools.TryGetValue(type, out var pool))
    //    {
    //        return pool.Get();
    //    }
    //    else
    //    {
    //        Debug.LogError($"Pool for Projectile ({type.ToString()}) does not exist");
    //        return null;
    //    }

    //}

    //public void ReturnToPool(ProjectileType type, Projectile projectile)
    //{
    //    if (projectile.gameObject.activeSelf)
    //    {
    //        if (projectilePools.TryGetValue(type, out var pool))
    //        {
    //            pool.Release(projectile);
    //        }
    //        else
    //        {
    //            throw new System.Exception($"Pool for Projectile ({type.ToString()}) does not exist");
    //        }
    //    }
    //}
}
