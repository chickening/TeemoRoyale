using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICardList : MonoBehaviour {

	// Use this for initialization
	[SerializeField]
	GameObject cardPrefeb;	// Need UICard Component
	[SerializeField]
	int _maxCardCapacity;
	public int maxCardCapacity
	{
		get
		{
			return _maxCardCapacity;
		}
		set
		{
			_maxCardCapacity = value;
		}
	}
	
	List<Card> cardList = new List<Card>();
	List<GameObject> cardObjectList = new List<GameObject>();
	int? selectedCard = null;
	public void AddCard(Card card, int index = -1)
	{
		if(index == -1)
		{
			cardList.Add(card);
			cardObjectList.Add(ObjectPoolManager.GetObjectPool(cardPrefeb).PopItem());
		}
		else
		{
			if(index < 0 || index >= cardList.Count)
			{
				cardList.Insert(index,card);
				cardObjectList.Insert(index, ObjectPoolManager.GetObjectPool(cardPrefeb).PopItem());
			}
		}
		UpdateCardList();
	}
	public void SelectCard(int index)
	{
		if(index < 0 || index >= cardList.Count)
			return;
		selectedCard = index;
		UpdateCardList();
	}
	public void DeselectCard()
	{
		selectedCard = null;
		UpdateCardList();
	}
	public void RemoveCard(int index)
	{
		if(index < 0 || index >= cardList.Count)
			return;
		if(selectedCard > index)
			--selectedCard;
		cardList.RemoveAt(index);
		UpdateCardList();
	}
	void UpdateCardList()
	{
		
	}
}
