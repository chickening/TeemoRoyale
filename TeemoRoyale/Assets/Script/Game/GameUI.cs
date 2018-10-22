using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour //Game UI 에 관한것들을 총괄하는 곳
{
    [SerializeField]
    UICardList cardList;
    [SerializeField]
	Card testCard;
    [SerializeField]
    UIBar resourceBar;
    [SerializeField]
    Text costText;
    void Start()
    {
        for(int i = 0; i < cardList.capacity; i++)
            cardList.AddCard(testCard);
        resourceBar.maxValue = 10;
    }
    void Update()
    {
        resourceBar.value = GameData.player.cost;
        costText.text = ((int)GameData.player.cost).ToString();
    }
}
