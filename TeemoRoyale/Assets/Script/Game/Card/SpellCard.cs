using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "SpellCard Data", order = 51)]
public class SpellCard : Card
{
    [SerializeField]
    Spell spell;

    public override void Active(Player player, Vector2 position)
    {
        if(player.cost < cost)
            return;
        player.cost -= cost;
        spell.Active(player, position);
    }
}
