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
        createdItem.name = prefab.name;
        PushItem(createdItem);
    }
    public GameObject PopItem()
    {
        if(objList.Count == 0)
            CreateItem();
        if(prefab.name.Equals("Gangplank"))
            Debug.Log(objList.Count);
        GameObject obj = objList.Dequeue();
        obj.SetActive(true);
        return obj;
    }
    public void PushItem(GameObject item)
    {
        item.SetActive(false);
        if(objList.Count >= capacity)
            Object.Destroy(item);
        objList.Enqueue(item);
    }
}