using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    public enum Type
    {
        PROP,
        CHARACTER,
        DAMAGER
    }
    string id;
    float hp;
    float maxHp;
    float damage;
    float speed;
    Type type;
    public Entity Clone()
    {
        return (Entity)MemberwiseClone();
    }
}