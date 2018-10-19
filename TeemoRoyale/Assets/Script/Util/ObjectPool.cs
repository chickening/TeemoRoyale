using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    GameObject prefab;  //id : name
    Queue<GameObject> objList = new Queue<GameObject>();
    public int capacity
    {
        get;
        set;
    }
    public ObjectPool(GameObject prefab, int capacity = 10)
    {
        this.prefab = prefab;
        this.capacity = capacity;
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
        GameObject obj = objList.Dequeue();
        obj.SetActive(true);
        return obj;
    }
    public void PushItem(GameObject item)
    {
        item.SetActive(false);
        if(objList.Count > capacity)
            Object.Destroy(item);
        objList.Enqueue(item);
    }
}