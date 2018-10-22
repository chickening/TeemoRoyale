using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRule : MonoBehaviour    // 게임 규칙을 설정하는곳
{
    [SerializeField]
    public float amountIncreaseCost;
    
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
        GameData.player.cost = Mathf.Clamp(GameData.player.cost + Time.deltaTime * amountIncreaseCost, 0f, 10f);
        GameData.enemyPlayer.cost = Mathf.Clamp(GameData.enemyPlayer.cost + Time.deltaTime * amountIncreaseCost, 0f, 10f);
    }

    public bool isRunningGame
    {
        get;
        private set;
    }
    
}