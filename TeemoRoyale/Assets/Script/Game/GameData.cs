using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData    // 게임 데이터를 저장한는곳
{
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
}