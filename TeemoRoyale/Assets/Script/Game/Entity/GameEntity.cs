using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class GameEntity : Entity    // BT에 의존
{    
    public int team
    {
        get;
        set;
    }//팀
    [SerializeField]
    float _hp;
    public float hp
    {
        private set { _hp = value; }
        get { return _hp; }
    }
    [SerializeField]
    float _maxHp;
    public float maxHp
    {
        get { return _maxHp; }
    }
    [SerializeField]
    float _damage;
    public float damage
    {
        get { return _damage; }
    }
    [SerializeField]
    float _speed;
    public float speed
    {
        get { return _speed; }
    }
    /*
        API
    */
    new Rigidbody2D rigidbody;
    List<Vector2> waypointList = new List<Vector2>();       // 이동경로
    public BTState Move()      // 엔티디 이동 함수
    {
        if(waypointList.Count == 0)
            return BTState.SUCCESS;

        Vector2 entityPos = transform.position;
        Vector2 moveDir = (waypointList[0] - entityPos).normalized;
        Vector2 nextPos;
        if((waypointList[0] - entityPos).sqrMagnitude <= Mathf.Pow(Time.deltaTime * speed, 2))
        {
            nextPos = waypointList[0];
            waypointList.RemoveAt(0);
        }
        else   
            nextPos = moveDir * Time.deltaTime * speed + entityPos;
        
        rigidbody.MovePosition(nextPos);
        return BTState.CONTINUE;
    }
    [SerializeField]
    float searchRadius;
    protected GameEntity target;
    public BTState SearchEnemy()
    {
        List<GameEntity> targets = GameData.field.FindEnemyGameEntityRadius(this, searchRadius);
        if(targets.Count == 0)
            return BTState.FAILURE;
        target = targets[0];
        return BTState.SUCCESS;
    }

    public void HitDamage(float damage)
    {
        /*
            나중에 Damage Indicator
         */
        hp = Mathf.Clamp(hp - damage, 0, maxHp);
        if(hp == 0)
            Die();
    }
    public void Die()
    {
        GameData.field.DeSpawn(gameObject);
    }

}
