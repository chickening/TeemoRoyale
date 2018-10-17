using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UICard : MonoBehaviour 
{

	[SerializeField]
	Text UICost;
	[SerializeField]
	Image UIImage;
	public int cost
	{
		set
		{
			UICost.text = value.ToString();
		}
		get
		{
			return int.Parse(UICost.text);
		}
	}
	public Sprite image
	{
		set
		{
			UIImage.sprite = value;
		}
		get
		{
			return UIImage.sprite;
		}
	}
}
