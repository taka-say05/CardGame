using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Effect
{
    public override void Trigger()
    {
        Debug.Log("Burn:" + this);
        carrierUnit.hp -= stack;
        Debug.Log(this + "HP:" + carrierUnit.hp);
        stack -= 2;
        if(stack < 0)
        {
            stack = 0;
        }
        Debug.Log("StackCount:" + stack);
    }
}
