using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICardList : MonoBehaviour 
{
	[SerializeField]
	GameObject uiCardPrefab;
	[SerializeField]
	int _capacity;
	public int capacity
	{
		get { return _capacity; }
	}
	[SerializeField]
	Vector2 spacing;
	List<UICard> uiCardList = new List<UICard>();
	int? selectedCard;
	[SerializeField]
	Player ownerPlayer;
	
	void Update()
	{
		Card[] playerHandCardArr = GameData.player[(int)Team.TEAM_PLAYER].handCardArr;
		if(playerHandCardArr.Length > uiCardList.Count)
		{
			AddCard(playerHandCardArr[uiCardList.Count]);
		}
	}
	public void AddCard(Card card)
	{
		GameObject newCardObj = ObjectPoolManager.GetObjectPool(uiCardPrefab).PopItem();
		UICard uiCard = newCardObj.GetComponent<UICard>();
		uiCard.transform.SetParent(gameObject.transform);
		uiCard.cardList = this;
		uiCard.card = card;
		uiCardList.Add(uiCard);
		uiCard.index = uiCardList.Count - 1;

		Rect cardTargetRect = GetCardPosition(uiCardList.Count - 1);
		Rect cardSizeRect = newCardObj.GetComponent<RectTransform>().rect;
		newCardObj.transform.localScale = new Vector2(cardTargetRect.width / cardSizeRect.width, cardTargetRect.height / cardSizeRect.height);

		Rect cardOrgRect = GetCardPosition(capacity - 1);
		CoroutineManager.RegisterCoroutine(AnimationUtil.MoveAnimationCoroutine(newCardObj, cardOrgRect.center, cardTargetRect.center ,0.5f));
		
	}
	public void SelectCard(int index)
	{
		/*
			테두리 애니메이션	// 쉐이더 되면 나중에 적용
		*/
		Card card = uiCardList[index].card;
		card.cardGuide.Enable();
	}
	public void DeselectCard()
	{
		if(selectedCard == null)
			return;

		uiCardList[(int)selectedCard].card.cardGuide.Disable();
	}

	public void UseCard(int index)
	{
		Card card = uiCardList[index].card;
		card.cardGuide.Disable();
		ObjectPoolManager.GetObjectPool(uiCardPrefab).PushItem(uiCardList[index].gameObject);
		uiCardList.RemoveAt(index);
		card.Active(GameData.player[(int)Team.TEAM_PLAYER], CameraUtil.GetMouseWorldPosition(Camera.main));

		for(int i = index; i < uiCardList.Count; i++)
		{
			Rect newCardRect = GetCardPosition(i);
			CoroutineManager.RegisterCoroutine(AnimationUtil
			.MoveAnimationCoroutine(uiCardList[i].gameObject, uiCardList[i].gameObject.transform.localPosition, newCardRect.center,0.5f));
			uiCardList[i].index = i;
		}
		
		GameData.player[(int)Team.TEAM_PLAYER].RemoveCardInHand(index);
	}
	Rect GetCardPosition(int index)
	{
		Rect cardRect = new Rect();
		Rect cardListSizeRect = gameObject.GetComponent<RectTransform>().rect;
		Rect cardSizeRect = uiCardPrefab.GetComponent<RectTransform>().rect;
		float cardWidthPx = (cardListSizeRect.width * gameObject.transform.localScale.x - spacing.x * (capacity + 2)) / capacity;
		float cardHeightPx = (cardListSizeRect.height * gameObject.transform.localScale.y - spacing.y * 2);
		cardRect.xMin = cardWidthPx * index + spacing.x * (index + 1);
		cardRect.xMax = cardRect.xMin + cardWidthPx;
		cardRect.yMin = spacing.y;
		cardRect.yMax = cardRect.yMin + cardHeightPx;

		cardRect.x -= cardListSizeRect.width * gameObject.transform.localScale.x / 2;
		cardRect.y -= cardListSizeRect.height * gameObject.transform.localScale.y / 2;
		return cardRect;
	}
	int GetIndex(Card card)
	{
		int index = -1;
		for(int i = 0; i < uiCardList.Count; i++)
			if(uiCardList[i].card.GetInstanceID() == card.GetInstanceID())
				index = i;
		return index;
	}
}
