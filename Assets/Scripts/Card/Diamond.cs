using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : Card
{
    public override void OnTurnStart()
    {
        ownerUnit.carryEffects.resistanseIncrease.AddStack(15, 8);
        base.OnTurnStart();
    }

    public override void Use()
    {
        Attack(10, attackType.Slash, attackAttribute.Crystal);

        Attack(5, attackType.Slash, attackAttribute.Crystal, Hit_2);

        ThirdAttack();
    }

    void Hit_2()
    {
        targetUnit.carryEffects.crystalize.AddStack(1);
    }

    void ThirdAttack()
    {
        Attack(3, attackType.Slash, attackAttribute.Crystal, Hit_3);
    }

    void Hit_3()
    {
        if (targetUnit.carryEffects.crystalize.stack >= 3)
        {
            targetUnit.carryEffects.crystalize.stack -= 1;
            ThirdAttack();
        }
    }
}
