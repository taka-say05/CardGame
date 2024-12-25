using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Card
{
    public override void OnTurnStart()
    {
        ownerUnit.resistanceBoost += 15;
        base.OnTurnStart();
    }

    public override void Use()
    {
        Attack(10, attackType.Slash, attackAttribute.Crystal);

        Attack(5, attackType.Slash, attackAttribute.Crystal, OnHit2);

        ThirdAttack();
    }

    void OnHit2()
    {
        targetUnit.carryEffects.crystallization.AddStack(1);
    }

    void ThirdAttack()
    {
        Attack(3, attackType.Slash, attackAttribute.Crystal);

        if (targetUnit.carryEffects.crystallization.stack >= 3)
        {
            targetUnit.carryEffects.crystallization.stack -= 1;
            ThirdAttack();
        }
    }
}
