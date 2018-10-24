using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour //Game UI 에 관한것들을 총괄하는 곳
{
    static GameUI instance;
    [SerializeField]
    GameObject canvasObject;
    [SerializeField]
    GameObject healthBarPrefab;
    [SerializeField]
    UICardList cardList;
    [SerializeField]
	Card testCard;
    [SerializeField]
    UIBar resourceBar;
    [SerializeField]
    Text costText;
    void Awake()
    {
        if(instance == null)
            instance = this;
    }
    void Start()
    {
        for(int i = 0; i < cardList.capacity; i++)
            cardList.AddCard(testCard);
        resourceBar.maxValue = 10;
    }
    void Update()
    {
        float playerCost = GameData.player[(int)Team.TEAM_PLAYER].cost;
        resourceBar.value = playerCost;
        costText.text = ((int)playerCost).ToString();
    }

    static public void AddHealthBar(GameEntity target)
    {
    
        GameObject healthBarObject = ObjectPoolManager.GetObjectPool(instance.healthBarPrefab).PopItem();
        UIHealthBar uiHealthBar = healthBarObject.GetComponent<UIHealthBar>();

        healthBarObject.transform.SetParent(instance.canvasObject.transform);
        uiHealthBar.target = target;
    }
}
