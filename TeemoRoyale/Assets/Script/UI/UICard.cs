using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class UICard : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	[SerializeField]
	Image imageBackground;
	[SerializeField]
	Text textCost;
	public UICardList cardList
	{
		get;
		set;
	}
	public int index
	{
		get;
		set;
	}
	public Sprite background
	{
		set
		{
			imageBackground.sprite = value;
		}
		get
		{
			return imageBackground.sprite;
		}
	}
	public int cost
	{
		set
		{
			textCost.text = value.ToString();
		}
		get
		{
			return int.Parse(textCost.text);
		}
	}
	Card _card;
	public Card card
	{
		set
		{
			_card = value;
			background = card.image;
			textCost.color = card.costColor;
			cost = card.cost;
		}
		get
		{ 
			return _card;
		}
	}
	bool isMouseDown = false;
	public void OnPointerDown(PointerEventData eventData)
	{
		if(card.cost > GameData.player[(int)Team.TEAM_PLAYER].cost)
			return;
		cardList.SelectCard(index);
		isMouseDown = true;
	}
	void OnMouseDrag()
	{

	}
	public void OnPointerUp(PointerEventData eventData)
	{
		if(!isMouseDown)
			return;
		isMouseDown = false;
		Rect cardListSizeRect = cardList.GetComponent<RectTransform>().rect;
		Vector2 mousePos = Input.mousePosition;
		/*카드 실패 조건 추가 */
		
		cardList.UseCard(index);
		
	}

}
