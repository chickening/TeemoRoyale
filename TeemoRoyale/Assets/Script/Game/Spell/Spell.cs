using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject
{
    [SerializeField]
    string _id;
    public string id
    {
        get { return _id; }
    }
    public void Active(Vector2 position)
    {

    }

}