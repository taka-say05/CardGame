using UnityEngine;

public class Laceration : Effect
{
    public override void Trigger()
    {
        carrierUnit.hp -= stack;
        DecrementStack((int)Mathf.Ceil(stack / 2.0f));
    }
}
