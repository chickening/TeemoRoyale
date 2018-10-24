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

    float lastGiveCardTime;
    public void Update()
    {
        for(int i = 0; i < GameData.player.Length; i++)
        {
            GameData.player[i].cost = Mathf.Clamp(GameData.player[i].cost + Time.deltaTime * GameData.player[i].amountIncreaseCost, 0, 10);
        }
        if(Time.time - lastGiveCardTime > GameData.giveCardDelay)
        {
            if(GameData.player[(int)Team.TEAM_PLAYER].handCardArr.Length < GameData.maxHandCardNum)
            {
                GameData.player[(int)Team.TEAM_PLAYER].AddCardInHand(GameData.cardArr[Random.Range(0, GameData.cardArr.Length)]);
                lastGiveCardTime = Time.time;            
            }
        }

        if(!GameData.player[(int)Team.TEAM_PLAYER].nexus.activeSelf && !GameData.isEnd)    // 게임 승패
        {
            GameUI.ShowPlayerLoseBanner();
            GameData.isEnd = true;
        }
        else if(!GameData.player[(int)Team.TEAM_ENEMY].nexus.activeSelf && !GameData.isEnd)
        {
            GameUI.ShowPlayerWinBanner();
            GameData.isEnd = true;
        }

    }

    public bool isRunningGame
    {
        get;
        private set;
    }
    
}