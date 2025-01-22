using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Burn : Effect
{
    public override void Trigger()
    {
        carrierUnit.hp -= stack;
        DecrementStack(2);
    }
}
