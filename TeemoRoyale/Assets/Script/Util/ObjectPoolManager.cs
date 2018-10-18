using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObjectPoolManager
{
    static Dictionary<string, ObjectPool> poolList = new Dictionary<string, ObjectPool>();

    static public ObjectPool FindObjectPool(GameObject obj)
    {
        ObjectPool pool = null;
        poolList.TryGetValue(obj.name, out pool);
        return pool;
    }
    static public ObjectPool GetObjectPool(GameObject obj)
    {
        ObjectPool pool = FindObjectPool(obj);
        if(pool == null)
            pool = CreateObjectPool(obj);
        return pool;
    }
    static public ObjectPool CreateObjectPool(GameObject obj)
    {
        ObjectPool pool = new ObjectPool(obj);
        poolList.Add(obj.name, pool);
        return pool;
    }

}