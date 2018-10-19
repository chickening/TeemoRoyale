using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffectA : GameEffect
{
    
    float elapsedTime;
    float continueTime;
    Vector2 orgPos;
    Vector2 targetPos;
    public void Init(Vector2 orgPos, Vector2 targetPos, float continueTime)
    {
        this.orgPos = orgPos;
        this.targetPos = targetPos;
        this.continueTime = continueTime;

        transform.position = orgPos;
        Vector2 dir = (targetPos - orgPos).normalized;
        
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));

        elapsedTime = 0;

    }
    protected override void Awake()
    {
        contoller = new MethodContoller(Tick);
    }
    void Tick()
    {
        elapsedTime += Time.deltaTime;
        transform.position = Vector2.Lerp(orgPos, targetPos, elapsedTime / continueTime);
        if(elapsedTime >= continueTime)
        {
            ObjectPoolManager.GetObjectPool(gameObject).PushItem(gameObject);
        }
    }
}