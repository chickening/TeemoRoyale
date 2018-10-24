using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CircleAreaAttackSpell", menuName = "CircleAreaAttackSpell Data", order = 51)]
public class CircleAreaAttackSpell : Spell
{
    [SerializeField]
    float preDelay;
    [SerializeField]
    float damage;
    [SerializeField]
    float radius;
    [SerializeField]
    GameObject preEffectPrefab;
    [SerializeField]
    GameObject damageEffectPrefab;
    [SerializeField]
    float damageEffectExposureTime;

    public override void Active(Player player, Vector2 position)
    {
        CoroutineManager.RegisterCoroutine(SpellCoroutine(player,position));
    }


    public IEnumerator SpellCoroutine(Player player, Vector2 position)
    {

        if(preEffectPrefab != null)
        {
            GameObject preEffect = GameData.field.Spawn(preEffectPrefab, position);
            CoroutineManager.RegisterCoroutine(AnimationUtil.DespawnAnimationCoroutine(preEffect, preDelay));
        }
        yield return new WaitForSeconds(preDelay);
        List<GameEntity> gameEntityList = GameData.field.FindEnemyGameEntityRadius(position, player.team, radius);
        for(int i = 0; i < gameEntityList.Count; i++)
        {
            gameEntityList[i].HitDamage(damage);
        }
        if(damageEffectPrefab != null)
        {
            GameObject damageEffect = GameData.field.Spawn(damageEffectPrefab, position);
            CoroutineManager.RegisterCoroutine(AnimationUtil.DespawnAnimationCoroutine(damageEffect, damageEffectExposureTime));
        }
    }
}