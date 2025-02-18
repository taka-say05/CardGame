using UnityEngine;

//å„Ç≈çÏÇÎÇ§
public class Jade : Card
{
    public override void OnTurnStart()
    {
        targetUnit.carryEffects.attackDecrease.AddStack(75, 8);

        base.OnTurnStart();
    }

    public override void Use()
    {
        FirstAttack();
    }

    void FirstAttack()
    {
        Attack(1, attackType.Impact, attackAttribute.Crystal, Hit_1);
    }

    void Hit_1()
    {
        targetUnit.carryEffects.resistanseDecrease.AddStack(10, (int)attackAttribute.Crystal + 3);
        targetUnit.carryEffects.crystalize.AddStack(1);
        targetUnit.carryEffects.attackDecrease.DecrementStack(25, 8);
        if (targetUnit.carryEffects.attackDecrease.stack[8] <= 0)
        {
            FirstAttack();
        }
        else
        {

        }
    }
}
