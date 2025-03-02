using UnityEngine;

public class Alexandrite : Card
{
    public override void Use()
    {

    }

    void Attack_1()
    {
        Attack(3, attackType.Pierce, attackAttribute.Crystal, Hit_1);
    }

    void Hit_1()
    {
        if (targetUnit.carryEffects.crystalize.stack >= 5)
        {
            int addValue = 0;
            addValue += targetUnit.carryEffects.attackIncrease.stack[8];
            targetUnit.carryEffects.attackIncrease.DecrementStack(0, 8, true);
            addValue += targetUnit.carryEffects.resistanseIncrease.stack[8];
            targetUnit.carryEffects.resistanseIncrease.DecrementStack(0, 8, true);

            targetUnit.carryEffects.resistanseDecrease.AddStack(addValue, 8);
        }
    }

    void Attack_2()
    {
        Attack(10, attackType.Pierce, attackAttribute.Crystal);
    }
}
