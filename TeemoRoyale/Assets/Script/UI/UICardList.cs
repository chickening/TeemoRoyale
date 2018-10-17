using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICardList : MonoBehaviour 
{

	// Use this for initialization
	[SerializeField]
	GameObject cardPrefab;
	[SerializeField]
	GameObject content;
	List<GameObject> cardObjectList = new List<GameObject>();
	List<Card> cardList = new List<Card>();

	void Awake()
	{
		GridLayoutGroup grid = content.GetComponent<GridLayoutGroup>();
		Rect sizeRect = cardPrefab.GetComponent<RectTransform>().rect;
		grid.cellSize = new Vector2(cardPrefab.transform.localScale.x * sizeRect.width, cardPrefab.transform.localScale.y * sizeRect.height);
		grid.spacing = new Vector2(5,0);
	}
	public void AddCard(Card card)
	{
		cardList.Add(card);
		RenderUpdate();
	}
	public void RemoveCard(int index)
	{
		cardList.RemoveAt(index);
		RenderUpdate();
	}
	public void RenderUpdate()
	{
		while(cardObjectList.Count > cardList.Count)
		{
			//cardObject 반환 코드 추가
		}

		while(cardObjectList.Count < cardList.Count)
		{
			//cardObject 추가 코드 추가
			//content밑에 삽입 코도 추가
		}

		int sizeCardList = cardList.Count;
		for(int i = 0; i < sizeCardList; i++)
		{
			UICard uiCard = cardObjectList[i].GetComponent<UICard>();
			uiCard.image = cardList[i].image;
			uiCard.cost = cardList[i].cost;
		}
	}
}
