using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTContoller : Contoller
{
    public BT bt
    {
        set;
        get;
    }
    
    public BTContoller(BT bt = null)
    {
        if(bt == null)
            this.bt = BT.Call(() => BTState.FAILURE);
        else
            this.bt = bt;
    }
    public override void Tick()
    {
        bt.Update();
    }
}  