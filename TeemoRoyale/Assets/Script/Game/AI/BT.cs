using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate bool ConditionDelegate();
public delegate BTState ExecutionDelegate();
public enum BTState
{
    FAILURE,
    SUCCESS,
    CONTINUE
}
public class BT
{
    public virtual BTState Update()
    {
        return BTState.FAILURE;
    }
    public static BTRoot Root(BT node)
    {
        return new BTRoot(node);
    }
    public static BT Selector(params BT[] nodes)
    {
        return new BTSelector(nodes);
    }
    public static BT Sequence(params BT[] nodes)
    {
        return new BTSequence(nodes);
    }
    public static BT Random(params BT[] nodes)
    {
        return new BTRandom(nodes);
    }
    public static BT Condition(ConditionDelegate condition, BT node)
    {
        return new BTCondition(condition, node);
    }
    public static BT While(ConditionDelegate condition, BT node)
    {
        return new BTWhile(condition, node);
    }
    public static BT Call(ExecutionDelegate exection)
    {
        return new BTCall(exection);
    }
    public static BT Wait(float delay)
    {
        return new BTWait(delay);
    }
    public static BT Probability(float probability, BT node)
    {
        return new BTProbability(probability, node);
    }
    public static BT Success(BT node)
    {
        return new BTSuccess(node);
    }

}

public class BTComposite:BT
{
    protected List<BT> child = new List<BT>();
    protected int childSize;
    protected BTComposite(params BT[] args)
    {
        if(args.Length == 0)
            return;
        int size = args.Length;
        for(int i = 0; i < size; i++)
        {
            child.Add(args[i]);
        }
        childSize = child.Count;
    }
}
public class BTRoot : BTDecorator
{
    public BTRoot(BT node) : base(node)
    {

    }
    public override BTState Update() // 나중에 계속
    {
        return child.Update();
    }
}
public class BTSelector : BTComposite
{
    public BTSelector(BT[] args) : base(args)
    {

    }
    public override BTState Update()
    {
        for(int i = 0; i < childSize; i++)
        {
            BTState state = child[i].Update();
            if(state == BTState.FAILURE)
                continue;
            else
                return state;
        }
        return BTState.SUCCESS;
    }
}
public class BTSequence : BTComposite
{
    public BTSequence(BT[] args) : base(args)
    {

    }
    public override BTState Update()
    {
        for(int i = 0; i < childSize; i++)
        {
            BTState state = child[i].Update();
            if(state == BTState.SUCCESS)
                continue;
            else
                return state;
        }
        return BTState.FAILURE;
    }
}
public class BTProbability : BTDecorator
{
    float probability;
    bool isFinish = false;
    public BTProbability(float _probability, BT _child) : base(_child)
    {
       probability = _probability;
    }
    public override BTState Update()
    {
        BTState state = BTState.FAILURE;
        if(isFinish && UnityEngine.Random.Range(0f,1f) <= probability)
            isFinish = false;
        if(!isFinish)
        {
            state = child.Update();
            if(state != BTState.CONTINUE)
                isFinish = true;
        }
        return state;
    }

}
public class BTRandom : BTComposite
{ 
    BT lastContinue = null;
    public BTRandom(BT[] args) : base(args)
    {

    }
    public override BTState Update()
    {
        
        BT selected;
        if(lastContinue != null)
            selected = lastContinue;
        else
            selected = child[UnityEngine.Random.Range(0,childSize - 1)];

        BTState state = selected.Update();
        if(state == BTState.CONTINUE)
            lastContinue = selected;
        else
            lastContinue = null;
        return state;
    }
}
public class BTDecorator : BT
{
    protected BT child;
    protected BTDecorator(BT _child)
    {
        child = _child;
    }
}
public class BTRepeat : BTDecorator
{
    int n;
    int processN = 0;
    public BTRepeat(int _n, BT _child) : base(_child)
    {
       n = _n;
    }
   public override BTState Update()
   {
       while(processN < n)
       {
           child.Update();
           ++processN;
           return BTState.CONTINUE;
       }
       processN = 0;
       return BTState.SUCCESS;
   }
}
public class BTCondition : BTDecorator
{
    ConditionDelegate condition;
    public BTCondition(ConditionDelegate _condition, BT _child) : base(_child)
    {
       condition = _condition;
    }

   public override BTState Update()
   {
       if(condition())
       {
           return child.Update();
       }
       return BTState.FAILURE;
   }
}

public class BTWhile : BTDecorator
{
    ConditionDelegate condition;
    BTState lastState;
    public BTWhile(ConditionDelegate _condition, BT _child) : base(_child)
    {
       condition = _condition;
    }

   public override BTState Update()
   {
       lastState = BTState.FAILURE; //처음에 끝나는거 방지
       if(condition())
       {
           lastState = child.Update();
           return BTState.CONTINUE;
       }
       else
           return lastState;
   }
}
public class BTSuccess : BTDecorator
{ 
    public BTSuccess(BT _child) : base(_child)
    {
    }

   public override BTState Update()
   {
       child.Update();
       return BTState.SUCCESS;
   }
}
public class BTLeaf : BT
{
}
public class BTCall : BTLeaf
{
    ExecutionDelegate execution;
    public BTCall(ExecutionDelegate _execution)
    {
        execution = _execution;
    }
    public override BTState Update()
    {
        return execution();
    }
}

public class BTWait : BTLeaf
{
    float delay;
    float elapsedTime = 0;
    public BTWait(float _delay)  //1 : 1초
    {
        delay = _delay;
    }
    public BTState wait()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime < delay)
            return BTState.CONTINUE;
        elapsedTime = 0;
        return BTState.SUCCESS;
    }
    public override BTState Update()
    {
        return wait();
    }
}