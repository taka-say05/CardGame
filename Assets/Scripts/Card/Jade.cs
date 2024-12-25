using UnityEngine;

public class Jade : Card
{
    public override void OnTurnStart()
    {
        targetUnit.carryEffects.attackDecrease.AddStack(75);

        base.OnTurnStart();
    }

    public override void Use()
    {
        Attack(2 * targetUnit.carryEffects.burn.stack, attackType.Impact, attackAttribute.Heat);
        targetUnit.carryEffects.burn.AddStack(5);

        Attack(8, attackType.Impact, attackAttribute.Heat);
    }
}
