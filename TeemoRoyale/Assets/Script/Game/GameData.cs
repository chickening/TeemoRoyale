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
    static public Player player
    {
        get;
        set;
    }
    static public Player enemyPlayer
    {
        get;
        set;
    }
}