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
    [SerializeField]
    GameObject towerPrefab;
    [System.Serializable]
    class TowerInfo
    {
        public int team;
        public Transform towerPosition;
    }
    [SerializeField]
    TowerInfo[] towerInfoArr;
    void Awake()
    {  
        if(instance == null)
            instance = this;
    }
    static public void GameLoad()
    {
        GameData.field = new Field();
        for(int i = 0; i < instance.towerInfoArr.Length; i++)
        {
            GameEntity entity = GameData.field.Spawn(instance.towerPrefab, instance.towerInfoArr[i].towerPosition.position).GetComponent<GameEntity>();
            entity.team = instance.towerInfoArr[i].team;
        }

        GameData.player = new Player();
        GameData.enemyPlayer = new Player();
    }
}