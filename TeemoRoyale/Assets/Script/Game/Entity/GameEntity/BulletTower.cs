using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTower : GameEntity
{
    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float fireDelay;
    float lastShootTime;
    public BTState Fire()
    {
        if(Time.time - lastShootTime <= fireDelay)
        {
            return BTState.CONTINUE; 
        }
        lastShootTime = Time.time;
        CoroutineManager.RegisterCoroutine(FireCoroutine());
        return BTState.SUCCESS;
    }
    IEnumerator FireCoroutine()
    {
        GameEntity target = this.target;
        GameObject bullet = GameData.field.Spawn(bulletPrefab, transform.position);
        BulletEffectA effectScript = bullet.GetComponent<BulletEffectA>();
        effectScript.Init(transform.position, target.transform.position, 1f);
        yield return new WaitForSeconds(1f);
        target.HitDamage(damage);
    }
    protected override void Awake()
    {
        base.Awake();
        this.contoller = new BTContoller
        (
            BT.Root
            (
                BT.Sequence
                (
                    BT.Call(SearchEnemy),
                    BT.Call(Fire)
                )
            )
        );
    }
}