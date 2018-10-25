using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHealthBar : MonoBehaviour 
{

	GameEntity _target;
	public GameEntity target
	{
		get
		{
			return _target;
		}
		set
		{
			_target = value;
			Sprite targetSprite = target.gameObject.GetComponent<SpriteRenderer>().sprite;
			spacingY = target.gameObject.transform.lossyScale.y * targetSprite.rect.height / targetSprite.pixelsPerUnit / 2  + 0.2f;
		}
	}
	[SerializeField]
	GameObject healthBarObject;
	[SerializeField]
	UIBar healthBar;
	
	float spacingY;


	void Update()
	{
		
		if(target == null || !target.gameObject.activeSelf)
			ObjectPoolManager.GetObjectPool(healthBarObject).PushItem(healthBarObject);
		
		
		healthBar.position = (Vector2)target.transform.position + new Vector2(0f, spacingY);
		healthBar.value = target.hp;
		healthBar.maxValue = target.maxHp;
	}
}
