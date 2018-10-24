using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationUtil
{
    static public IEnumerator MoveAnimationCoroutine(GameObject obj, Vector2 orgPos, Vector2 targetPos, float progressTime)
    {
        float elpasedTime = 0;
        while(progressTime > elpasedTime)
        {
            obj.transform.localPosition = Vector2.Lerp(orgPos, targetPos, elpasedTime / progressTime);
            elpasedTime += Time.deltaTime;
            yield return null;
        }
    }
    static public IEnumerator DestoryAnimationCoroutine(GameObject obj, float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        ObjectPoolManager.GetObjectPool(obj).PushItem(obj);
    }

    static public IEnumerator DespawnAnimationCoroutine(GameObject obj , float lifeTime)
    {
        yield return new WaitForSeconds(lifeTime);
        GameData.field.Despawn(obj);
    }
}