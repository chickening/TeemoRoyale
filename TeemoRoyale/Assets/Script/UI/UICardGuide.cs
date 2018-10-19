using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICardGuide : ScriptableObject
{
    [SerializeField]
    string _id;
    public string id
    {
        get { return _id; }
    }
    [SerializeField]
    GameObject guidePrefab;
    [SerializeField]
    float size;

    GameObject guideObject;
    bool isEnabled;
    Coroutine coroutine;
    public void Enable()
    {
        isEnabled = true;
        GameCoroutineManager.RegisterCoroutine(VisibleCoroutine());
    }
    public void Disable()
    {
        isEnabled = false;
    }

    IEnumerator VisibleCoroutine()
    {
        guideObject = ObjectPoolManager.GetObjectPool(guidePrefab).PopItem();
        while(isEnabled)
        {
            guideObject.transform.position = Input.mousePosition;
            yield return null;
        }
        ObjectPoolManager.GetObjectPool(guideObject).PushItem(guideObject);
    }
    
}