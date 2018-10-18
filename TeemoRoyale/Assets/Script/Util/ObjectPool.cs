using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    GameObject prefab;  //id : name
    Queue<GameObject> objList;
    public int capacity
    {
        get;
        set;
    }
    
    public void CreateItem()
    {
        GameObject createdItem = Object.Instantiate(prefab);
        PushItem(createdItem);
        createdItem.name = prefab.name;
    }
    public GameObject PopItem()
    {
        if(objList.Count == 0)
            CreateItem();
        return objList.Dequeue();
    }
    public void PushItem(GameObject item)
    {
        if(objList.Count > capacity)
            Object.Destroy(item);
        objList.Enqueue(item);
    }
}