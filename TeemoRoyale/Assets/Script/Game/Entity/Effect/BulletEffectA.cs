using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEffectA : GameEffect
{
    
    public void Init(Vector2 orgPos, Vector2 targetPos, float progressTime)
    {
        Vector2 dir = (targetPos - orgPos).normalized;
        transform.rotation = Quaternion.Euler(new Vector3(0,0,Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
        this.StartCoroutine(AnimationUtil.MoveAnimationCoroutine(gameObject, orgPos, targetPos, progressTime));
        this.StartCoroutine(AnimationUtil.DespawnAnimationCoroutine(gameObject, progressTime));
    }
    protected override void Awake()
    {
        
    }
}