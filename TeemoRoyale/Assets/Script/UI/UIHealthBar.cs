using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
	SpriteRenderer heathBasSpriteRenderer;

	void Awake()
	{
		heathBasSpriteRenderer = healthBarObject.GetComponent<SpriteRenderer>();
	}
	void Update()
	{
		
		if(target == null || !target.gameObject.activeSelf)
			ObjectPoolManager.GetObjectPool(healthBarObject).PushItem(healthBarObject);
		
			
		if(target.team == Team.TEAM_PLAYER)
           	heathBasSpriteRenderer.color = GameData.playerColor;
		else if(target.team == Team.TEAM_ENEMY)
			heathBasSpriteRenderer.color = GameData.enemyColor;
			
		healthBar.position = (Vector2)target.transform.position + new Vector2(0f, spacingY);
		healthBar.value = target.hp;
		healthBar.maxValue = target.maxHp;
	}
}
