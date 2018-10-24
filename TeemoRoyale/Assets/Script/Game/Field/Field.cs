using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    List<Entity> entityList = new List<Entity>();

    public void AddEntity(Entity entity)
    {
        entityList.Add(entity);
    }
    public void RemoveEntity(Entity entity)
    {
        entityList.Remove(entity);
    }
    public List<GameEntity> FindGameEntityRadius(Vector2 position, float radius)
    {
        List<GameEntity> suitableEntityList = new List<GameEntity>();
        
        int size = entityList.Count;
        float sqrRadius = radius * radius;
        for(int i = 0 ; i < size; i++)
        {  
            if(!(entityList[i] is GameEntity))
                continue;
            GameEntity gameEntity = entityList[i] as GameEntity;
            if(sqrRadius >= ((Vector2)gameEntity.transform.position - position).sqrMagnitude)
                suitableEntityList.Add(gameEntity);
        }
        return suitableEntityList;
    }// Position을 중심으로 radius 안의 엔티티 반환
    public List<GameEntity> FindEnemyGameEntityRadius(GameEntity entity, float radius)
    {
        return FindEnemyGameEntityRadius(entity.transform.position, entity.team, radius);
    }//entity 를 중심으로 radius안의 같은인팀이 아닌 entity 반환

    public List<GameEntity> FindEnemyGameEntityRadius(Vector2 position, Team team , float radius)
    {
        List<GameEntity> suitableEntityList = new List<GameEntity>();

        int size = entityList.Count;
        float sqrRadius = radius * radius;
        for(int i = 0 ; i < size; i++)
        {  
            if(!(entityList[i] is GameEntity))
                continue;
            GameEntity gameEntity = entityList[i] as GameEntity;
            if(sqrRadius >= ((Vector2)gameEntity.transform.position - position).sqrMagnitude && gameEntity.team != team)
                suitableEntityList.Add(gameEntity);
        }
        return suitableEntityList;
    }//position을 중심으로 radius안의 team이랑 다른 팀의 엔티티를 반환

    public GameObject Spawn(GameObject prefab, Vector2 position)
    {
        GameObject obj = ObjectPoolManager.GetObjectPool(prefab).PopItem();
        obj.transform.position = position;
        Entity entity = obj.GetComponent<Entity>();
        AddEntity(entity);
        if(entity is GameEntity)
        {
            GameUI.AddHealthBar(entity as GameEntity);
        }
        return obj;
    }
    public void Despawn(GameObject item)
    {
        RemoveEntity(item.GetComponent<Entity>());
        ObjectPoolManager.GetObjectPool(item).PushItem(item);
    }


}
