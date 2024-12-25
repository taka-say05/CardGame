using UnityEngine;

public class Bleeding : Effect
{
    public override void Trigger()
    {
        Debug.Log("Bleeding:" + this);
        carrierUnit.hp -= stack;
        Debug.Log(this + "HP:" + carrierUnit.hp);
        stack /= 2;
        Debug.Log("StackCount:" + stack);
    }
}
