using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerPlayer : MonoBehaviour {

	[SerializeField]
	float useCardDelay;
	// Use this for initialization
	float lastUseCardTime;
	void Awake () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!GameData.isEnd)
		{

			if(Time.time - lastUseCardTime > useCardDelay)
			{
				Card[] cardArr = GameData.cardArr;

				Card selectedCard = cardArr[Random.Range(0, cardArr.Length)];
				if(selectedCard is SpellCard)
				{
					selectedCard.Active(GameData.player[(int)Team.TEAM_ENEMY]
						, new Vector2(GameData.playerRect.xMin + Random.Range(0,GameData.playerRect.width), GameData.playerRect.yMin + Random.Range(0, GameData.playerRect.height)));
				}
				else if(selectedCard is SpawnCard)
				{
					selectedCard.Active(GameData.player[(int)Team.TEAM_ENEMY]
						, new Vector2(GameData.enemyRect.xMin + Random.Range(0,GameData.enemyRect.width), GameData.enemyRect.yMin + Random.Range(0, GameData.enemyRect.height)));
				}
				lastUseCardTime = Time.time;
			}
		}

	}
}
