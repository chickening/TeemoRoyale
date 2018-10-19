using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameRule))]
[RequireComponent(typeof(GameLoader))]
[RequireComponent(typeof(GameCoroutineManager))]
public class GameCore : MonoBehaviour       //게임 코어 게임의 모든것을 통제하는곳
{
    public void Start()
    {
        GameLoader.GameLoad();
    }
}