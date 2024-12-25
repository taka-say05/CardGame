using UnityEngine;

public class Poison : Effect
{
    public override void Trigger()
    {
        Debug.Log("Poison");
        carrierUnit.hp -= (carrierUnit.hp * stack / 100);
        Debug.Log(this + "HP:" + carrierUnit.hp);
        stack /= 2;
        Debug.Log(this + "StackCount:" + stack);
    }
}
