using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    GameObject entityPrefab;
    [SerializeField]
    string _id;
    public string id
    {
        get { return _id; }
    }    
    public Entity Clone()
    {
        return (Entity)MemberwiseClone();
    }
}
public class GameEntity : Entity    // BT에 의존
{

    [SerializeField]
    float _hp;
    public float hp
    {
        get { return _hp; }
    }
    [SerializeField]
    float _maxHp;
    public float maxHp
    {
        get { return _maxHp; }
    }
    [SerializeField]
    float _damage;
    public float damage
    {
        get { return _damage; }
    }
    [SerializeField]
    float _speed;
    public float speed
    {
        get { return _speed; }
    }
}

public class Tower : GameEntity
{
    void Update()
    {

    }
}