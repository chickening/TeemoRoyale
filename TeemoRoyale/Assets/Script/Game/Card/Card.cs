using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardData", menuName = "Card Data", order = 51)]
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
    Color _costColor;
    public Color costColor
    {
        get { return _costColor; }
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
    UICardGuide _cardGuide;
    public UICardGuide cardGuide
    {
        get{ return _cardGuide; }
    }
    [SerializeField]
    float guideSize;

    public virtual void Active(Player player, Vector2 position)
    {


    }// 카드를 사용하면 호출됨
    public Card Clone()
    {
        return (Card)MemberwiseClone();
    }
}
