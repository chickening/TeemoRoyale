using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour    // 게임 규칙을 설정하는곳
{
    static public GameRule instance
    {
        get;
        private set;
    }

    public GameObject guideObject;
    public void Awake()
    {
        if(instance == null)
            instance = this;
    }
    public void Update()
    {

    }

    public bool isRunningGame
    {
        get;
        private set;
    }
    
}