using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "New CardGuideData", menuName = "CardGuide Data", order = 51)]
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
    GameObject guideObject;
    bool isEnabled;
    Coroutine coroutine;
    public void Enable()
    {
        isEnabled = true;
        CoroutineManager.RegisterCoroutine(VisibleCoroutine());
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
            guideObject.transform.position = CameraUtil.GetMouseWorldPosition(Camera.main);
            yield return null;
        }
        ObjectPoolManager.GetObjectPool(guideObject).PushItem(guideObject);
        yield return null;
    }
    
}