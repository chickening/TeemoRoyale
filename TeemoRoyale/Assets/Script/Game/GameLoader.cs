using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoader : MonoBehaviour // 게임 리소스를 로딩 하는곳
{
    Card[] loadingCardArr;
    Entity[] loadingEntityArr;
    public void Awake()
    {
        int tempSize = loadingCardArr.Length;
        for(int i = 0 ; i < tempSize; i++)
        {
            GameData.AddCard(loadingCardArr[i]);
        }
    }
}