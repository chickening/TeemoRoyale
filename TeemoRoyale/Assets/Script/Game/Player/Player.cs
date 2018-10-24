using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public Team team
    {
        get;
        set;
    }
    public float cost
    {
        get;
        set;
    }
    public Path[] availablePath
    {
        get;
        set;
    }
    
    public float amountIncreaseCost
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
public class UserData
{
    CardIventory cardIventory;
}
public class CardIventory
{
    List<Card> deck;
    List<Card> ownCards;
    
}
public enum Team
{
    TEAM_PLAYER = 0,
    TEAM_ENEMY = 1
}