using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : GameEntity
{
    [SerializeField]
    float minAttackDistance;
    [SerializeField]
    float attackDelay;
    protected override void Awake()
    {
        base.Awake();
        this.contoller = new BTContoller
        (
            BT.Root
            (
                BT.Selector
                (
                     BT.Sequence
                    (
                        BT.Call(SearchEnemy),
                        BT.Call(WaypointToTarget),
                        BT.Call(Move),
                        BT.Call(Attack)
                    )
                    ,
                    BT.Sequence
                    (
                        BT.Call(FindWayPoint),
                        BT.Call(Move)
                    )
                )
            )
        );
    }
    
    int attackState = 0;
    float lastAttackTime;
    public BTState Attack()
    {
        Vector2 orgPos = target.transform.position;
        Vector2 targetPos = target.transform.position;
        float distance = Mathf.Sqrt((orgPos - targetPos).sqrMagnitude);
        if(distance < minAttackDistance)
        {
            if(Time.time - lastAttackTime > attackDelay)
            {
                target.HitDamage(damage);
                lastAttackTime = Time.time;
            }
            if(!target.enabled)
            {
                target = null;
                return BTState.SUCCESS;
            }
            return BTState.CONTINUE;
        }
        else
            return BTState.FAILURE;
    }
    public BTState WaypointToTarget()
    {
        if(target == null)
            return BTState.FAILURE;
        Vector2 orgPos = target.transform.position;
        Vector2 targetPos = target.transform.position;
        float distance = Mathf.Sqrt((orgPos - targetPos).sqrMagnitude);
        waypointList = new List<Vector2>();


        if(distance <= minAttackDistance)
            return BTState.SUCCESS;
        else
            waypointList.Add(Vector2.Lerp(orgPos, targetPos, (distance - minAttackDistance) / distance));
        return BTState.SUCCESS;
    }

}