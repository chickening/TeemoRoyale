using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineManager : MonoBehaviour
{
    static public CoroutineManager instance
    {
        get;
        private set;
    }
    //static public List<Coroutine> coroutineList = new List<Coroutine>();

    void Awake()
    {
        if(instance == null)
            instance = this;
    }
    
    static public Coroutine RegisterCoroutine(IEnumerator coroutineFunc)
    {
        Coroutine coroutine  = instance.StartCoroutine(coroutineFunc);
        //coroutineList.Add(coroutine);
        return coroutine;
    }
    static public void ReleaseCoroutine(Coroutine coroutine)
    {
        instance.StopCoroutine(coroutine);
        //coroutineList.Remove(coroutine);
    }
}