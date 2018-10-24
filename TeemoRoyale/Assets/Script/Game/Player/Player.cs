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
    public GameObject nexus
    {
        get;
        set;
    }
    Stack<Card> deck;
    List<Card> handCardList = new List<Card>();
    public void PushCardInDeck(Card card)
    {
        deck.Push(card);
    }
    public Card PushCardInDeck()
    {
        if(deck.Count == 0)
            return null;
        return deck.Pop();
    }
    public Card[] handCardArr
    {
        get { return handCardList.ToArray(); }
    }
    public void AddCardInHand(Card card)
    {
        handCardList.Add(card);
    }
    public void RemoveCardInHand(int index)
    {
        handCardList.RemoveAt(index);
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