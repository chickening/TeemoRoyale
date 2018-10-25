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
    UIBar resourceBar;
    [SerializeField]
    Text costText;
    [SerializeField]
    GameObject playerWinBannerPrefab;
    [SerializeField]
    GameObject playerLoseBannerPrefab;
    void Awake()
    {
        if(instance == null)
            instance = this;
    }
    void Start()
    {
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

        uiHealthBar.target = target;
    }
    static public void ShowPlayerWinBanner()
    {
        GameObject winBanner = ObjectPoolManager.GetObjectPool(instance.playerWinBannerPrefab).PopItem();
        winBanner.transform.position = new Vector2(0, -Camera.main.pixelHeight / 2);
        winBanner.transform.SetParent(instance.canvasObject.transform);
        CoroutineManager.RegisterCoroutine(AnimationUtil.MoveAnimationCoroutine(winBanner, winBanner.transform.position , new Vector2(0,0), 2f));
        CoroutineManager.RegisterCoroutine(AnimationUtil.DestoryAnimationCoroutine(winBanner, 10f));
    }
    static public void ShowPlayerLoseBanner()
    {
        GameObject loseBanner = ObjectPoolManager.GetObjectPool(instance.playerLoseBannerPrefab).PopItem();
        loseBanner.transform.position = new Vector2(0, -Camera.main.pixelHeight / 2);
        loseBanner.transform.SetParent(instance.canvasObject.transform);
        CoroutineManager.RegisterCoroutine(AnimationUtil.MoveAnimationCoroutine(loseBanner, loseBanner.transform.position , new Vector2(0,0), 2f));
        CoroutineManager.RegisterCoroutine(AnimationUtil.DestoryAnimationCoroutine(loseBanner, 10f));
    }
}
