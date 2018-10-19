using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    string _id;
    public string id
    {
        get { return _id; }
    }
    public Contoller contoller;
    public Entity Clone()
    {
        return (Entity)MemberwiseClone();
    }

    protected virtual void Awake()
    {

    }
    protected virtual void Start()
    {
        
    }
    protected virtual void Update()
    {
        contoller.Tick();
    }
}