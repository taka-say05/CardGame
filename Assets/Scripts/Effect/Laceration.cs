using UnityEngine;

public class Laceration : Effect
{
    public override void Trigger()
    {
        Debug.Log("Laceration");
        carrierUnit.hp -= stack;
        Debug.Log(this +  "HP:" + carrierUnit.hp);
        stack /= 2;
        Debug.Log(this +  "StackCount:" + stack);
    }
}
