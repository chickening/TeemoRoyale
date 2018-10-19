using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void TickDelegate();
public class MethodContoller : Contoller
{
    TickDelegate tick;
    public MethodContoller(TickDelegate tick)
    {
        this.tick = tick;
    }
    public override void Tick()
    {
        tick();
    }
}  