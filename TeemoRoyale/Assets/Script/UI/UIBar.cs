using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBar : MonoBehaviour {

	/*
		inverse 구현하기
	 */
	[SerializeField]
	GameObject bar;
	[SerializeField]
	bool _isHorizontal;
	public bool isHorizontal
	{
		get
		{
			return _isHorizontal;
		}
		set
		{
			_isHorizontal = value;
			UpdateBar();
		}
	}
	float _value;
	public float value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
			UpdateBar();
		}
	}
	float _maxValue = 1;
	public float maxValue
	{
		get
		{
			return _maxValue;
		}
		set
		{
			_maxValue = value;
			UpdateBar();
		}
	}
	public Vector2 position
	{
		set
		{
			orgPosition = value;
			UpdateBar();
		}
		get
		{
			return orgPosition;
		}

	}
	Vector2 orgScale;
	Vector2 orgPosition;
	Rect sizeRect;
	void Awake()
	{
		orgScale.x = bar.transform.localScale.x;
		orgScale.y = bar.transform.localScale.y;
		orgPosition.x = bar.transform.localPosition.x;
		orgPosition.y = bar.transform.localPosition.y;

		RectTransform rectTrasnfrom = bar.GetComponent<RectTransform>();
		if(rectTrasnfrom != null)
		{
			sizeRect = rectTrasnfrom.rect;
		}
		else
		{
			Sprite sprite =	bar.GetComponent<SpriteRenderer>().sprite;
			sizeRect = new Rect(0, 0, sprite.rect.width / sprite.pixelsPerUnit, sprite.rect.height / sprite.pixelsPerUnit);
		}
	}

	void UpdateBar()
	{
		float percent = Mathf.Clamp(value / maxValue, 0f, 1f);
		if(isHorizontal)
		{
			bar.transform.localScale = new Vector2(orgScale.x * percent, orgScale.y);
			bar.transform.localPosition = new Vector2(orgPosition.x - (1 - percent) * sizeRect.width * orgScale.x / 2, orgPosition.y);
		}
		else
		{
			bar.transform.localScale = new Vector2(orgScale.x, orgScale.y * percent);
			bar.transform.localPosition = new Vector2(orgPosition.x , orgPosition.y  - (1 - percent) * sizeRect.height * orgScale.y / 2);
		}
	}
}
