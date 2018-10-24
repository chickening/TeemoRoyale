using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour 
{

	public GameEntity target
	{
		get;
		set;
	}
	[SerializeField]
	GameObject healthBarObject;
	[SerializeField]
	UIBar healthBar;
	void Update()
	{
		
		if(target == null || !target.gameObject.activeSelf)
			ObjectPoolManager.GetObjectPool(healthBarObject).PushItem(healthBarObject);
		healthBarObject.transform.position = (Vector2)Camera.main.WorldToScreenPoint((Vector2)target.transform.position) - Camera.main.pixelRect.center + new Vector2(0f,140f);
		healthBar.MovePosition(healthBarObject.transform.position);
		healthBar.value = target.hp;
		healthBar.maxValue = target.maxHp;
	}
}
