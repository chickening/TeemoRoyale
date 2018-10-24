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
	float _maxValue;
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
	float orgXScale;
	float orgYScale;
	float orgX;
	float orgY;
	float width;
	float height;
	void Awake()
	{
		orgXScale = bar.transform.localScale.x;
		orgYScale = bar.transform.localScale.y;
		orgX = bar.transform.localPosition.x;
		orgY = bar.transform.localPosition.y;
		Rect sizeRect = bar.GetComponent<RectTransform>().rect;
		width = sizeRect.width;
		height = sizeRect.height;
	}
	void Start () 
	{

	}
	void UpdateBar()
	{
		float percent = Mathf.Clamp(value / maxValue, 0f, 1f);
		if(isHorizontal)
		{
			bar.transform.localScale = new Vector2(orgXScale * percent, orgYScale);
			bar.transform.localPosition = new Vector2(orgX - (1 - percent) * width * orgXScale / 2, orgY);
		}
		else
		{
			bar.transform.localScale = new Vector2(orgXScale, orgYScale * percent);
			bar.transform.localPosition = new Vector2(orgX, orgY - (1 - percent) * height * orgYScale / 2);
		}
	}
	public void MovePosition(Vector2 pos)
	{
		orgX = pos.x;
		orgY = pos.y;
	}
}
