using UnityEngine;

public class Poison : Effect
{
    public override void Trigger()
    {
        carrierUnit.hp -= (carrierUnit.hp * stack / 100);
        DecrementStack((int)Mathf.Ceil(stack / 2.0f));
    }
}
