using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour   // 게임 데이터를 저장한는곳
{
    static GameData instance;
    void Awake()
    {
        if(instance == null)
            instance = this;
    }
    
    [SerializeField]
    Path[] _playerPath;
    static public Path[] playerPath
    {
        get
        {
            return instance._playerPath;
        }
    }
    [SerializeField]
    Path[] _enemyPath;
    static public Path[] enemyPath
    {
        get
        {
            return instance._enemyPath;
        }
    }
    [SerializeField]
    GameObject _towerPrefab;
    public static GameObject towerPrefab
    {
        get{ return instance._towerPrefab; }
    }
    [System.Serializable]
    public class TowerInfo
    {
        public Team team;
        public Transform towerPosition;
    }
    [SerializeField]
    TowerInfo[] _towerInfoArr;

    public static TowerInfo[] towerInfoArr
    {
        get
        {
            return instance._towerInfoArr;
        }
    }
    [System.Serializable]
    public class NexusInfo
    {
        public Team team;
        public Transform nexusPosition;
    }
    [SerializeField]
    NexusInfo[] _nexusInfoArr;
    public static NexusInfo[] nexusInfoArr
    {
        get
        {
            return instance._nexusInfoArr;
        }
    }
    [SerializeField]
    GameObject _nexusPrefab;
    static public GameObject nexusPrefab
    {
        get
        {
            return instance._nexusPrefab;
        }
    }
    [SerializeField]
    float _amountIncreaseCost;
    static public float amountIncreaseCost
    {
        get { return instance._amountIncreaseCost; }
        set { instance._amountIncreaseCost = value;}
    }
    [SerializeField]
    Card[] _cardArr;
    static public Card[] cardArr
    {
        get { return instance._cardArr; }
    }
    [SerializeField]
    int _maxHandCardNum;
    static public int maxHandCardNum
    {
        get { return instance._maxHandCardNum; }
    }

    [SerializeField]
    public float _giveCardDelay;
    static public float giveCardDelay
    {
        get { return instance._giveCardDelay; }
    }
    static public bool isEnd
    {
        get;
        set;
    }
    static public bool isPlaying
    {
        get;
        set;
    }
    static public Field field
    {
        get;
        set;
    } 
    static public Player[] player
    {
        get;
        set;
    }
}