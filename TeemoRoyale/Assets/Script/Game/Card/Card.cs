using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : ScriptableObject
{
    [SerializeField]
    string _id;
    public string id
    {
        get{ return _id; }
    }
    [SerializeField]
    int _cost;
    public int cost
    {
        get { return _cost; }
    }
    [SerializeField]
    Sprite _image;
    public Sprite image
    {
        get { return _image; }
    }
    [SerializeField]
    string _desription;
    public string description
    {
        get { return _desription; }
    }
    [SerializeField]
    UICardGuide cardGuide;
    [SerializeField]
    float guideSize;

    public virtual void Active(Vector2 position)
    {


    }// 카드를 사용하면 호출됨
    public Card Clone()
    {
        return (Card)MemberwiseClone();
    }
}

public class SpawnCard : Card
{
    [SerializeField]
    GameObject spawnEntityPrefab;
    [SerializeField]
    int spawnNum;

    public override void Active(Vector2 position)
    {
        for(int i = 0; i < spawnNum; i++)
        {
            GameData.field.Spawn(spawnEntityPrefab, position);
        }
    }
}
public class SpellCard : Card
{
    [SerializeField]
    Spell spell;

    public override void Active(Vector2 position)
    {
        spell.Active(position);
    }
}
