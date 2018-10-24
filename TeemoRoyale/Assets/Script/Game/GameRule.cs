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
    public void Awake()
    {
        if(instance == null)
            instance = this;
    }
    public void Update()
    {
        for(int i = 0; i < GameData.player.Length; i++)
        {
            GameData.player[i].cost = Mathf.Clamp(GameData.player[i].cost + Time.deltaTime * GameData.player[i].amountIncreaseCost, 0, 10);
        }
    }

    public bool isRunningGame
    {
        get;
        private set;
    }
    
}