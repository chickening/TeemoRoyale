using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public int team //0 : RED 1 : BLUE
    {
        get;
        set;
    }
    public float cost
    {
        get;
        set;
    }
    Stack<Card> deck;
    public void PushCard(Card card)
    {
        deck.Push(card);
    }
    public Card PopCard()
    {
        if(deck.Count == 0)
            return null;
        return deck.Pop();
    }
}
public class PlayerData
{
    CardIventory cardIventory;
}
public class CardIventory
{
    List<Card> deck;
    List<Card> ownCards;
    
}
