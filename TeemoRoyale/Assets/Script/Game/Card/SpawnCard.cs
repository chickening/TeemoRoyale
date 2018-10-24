using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "SpawnCard Data", order = 51)]

public class SpawnCard : Card
{
    [SerializeField]
    GameObject spawnEntityPrefab;
    [SerializeField]
    int spawnNum;

    public override void Active(Player player, Vector2 position)   // 나중에 Parameter에 Player 추가
    {
        if(player.cost < cost)
            return;
        player.cost -= cost;
        for(int i = 0; i < spawnNum; i++)
        {
            GameEntity entity = GameData.field.Spawn(spawnEntityPrefab, position).GetComponent<GameEntity>();
            entity.team = player.team;
        }
    }
}