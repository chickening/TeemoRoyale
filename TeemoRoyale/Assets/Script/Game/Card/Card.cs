using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
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
    public virtual void PreActive()
    {


    }
    public virtual void Active()
    {


    }
    public Card Clone()
    {
        return (Card)MemberwiseClone();
    }
}
