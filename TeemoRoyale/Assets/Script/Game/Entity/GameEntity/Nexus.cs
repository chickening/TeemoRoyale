using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nexus : GameEntity
{
    protected override void Awake()
    {
        this.contoller = new BTContoller();
    }
}