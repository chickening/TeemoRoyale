using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour // 게임 리소스를 로딩 하는곳
{

    static public GameLoader instance
    {
        get;
        private set;
    }
    void Awake()
    {  
        if(instance == null)
            instance = this;
    }
    static public void GameLoad()
    {
        GameData.field = new Field();
        for(int i = 0; i < GameData.towerInfoArr.Length; i++)
        {
            GameEntity entity = GameData.field.Spawn(GameData.towerPrefab, GameData.towerInfoArr[i].towerPosition.position).GetComponent<GameEntity>();
            entity.team = GameData.towerInfoArr[i].team;
        }
        Player[] playerArr = new Player[2];
        for(int i = 0; i < playerArr.Length; i++)
            playerArr[i] = new Player();
        for(int i = 0; i < GameData.nexusInfoArr.Length; i++)
        {
            GameEntity entity = GameData.field.Spawn(GameData.nexusPrefab, GameData.nexusInfoArr[i].nexusPosition.position).GetComponent<GameEntity>();
            entity.team = GameData.nexusInfoArr[i].team;
            playerArr[(int)GameData.nexusInfoArr[i].team].nexus = entity.gameObject;
        }
        
        for(int i = 0; i < playerArr.Length; i++)
            playerArr[i].amountIncreaseCost = GameData.amountIncreaseCost;
        playerArr[(int)Team.TEAM_PLAYER].availablePath = GameData.playerPath;
        playerArr[(int)Team.TEAM_ENEMY].availablePath = GameData.enemyPath;
        GameData.player = playerArr;
        GameData.isEnd = false;

        Screen.SetResolution(Screen.width, (int)(Screen.width * 9f / 16f),true);
    }
}