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

    static Dictionary<string, Card> cardList;
    static public void AddCard(Card card)
    {
        cardList.Add(card.id, card);
    }
    static public Card FindCard(string id)
    {
        Card card = null;
        cardList.TryGetValue(id, out card);
        return card;
    }

}