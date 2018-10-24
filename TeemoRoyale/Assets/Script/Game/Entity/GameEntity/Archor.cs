using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archor : GameEntity
{
    [SerializeField]
    float attackDelay;
    [SerializeField]
    GameObject projectilePrefab; 
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
        if(distance < attackDistance)
        {
            if(Time.time - lastAttackTime > attackDelay)
            {
                CoroutineManager.RegisterCoroutine(FireCoroutine());
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
    IEnumerator FireCoroutine()
    {
        GameEntity target = this.target;
        GameObject projectile = GameData.field.Spawn(projectilePrefab, transform.position);
        BulletEffectA effectScript = projectile.GetComponent<BulletEffectA>();
        effectScript.Init(transform.position, target.transform.position, 1f);
        yield return new WaitForSeconds(1f);
        if(target.gameObject.activeSelf)
            target.HitDamage(damage);
    }
}