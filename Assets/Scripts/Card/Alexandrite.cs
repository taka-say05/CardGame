using UnityEngine;

public class Alexandrite : Card
{
    public override void Use()
    {
        Attack(3, attackType.Pierce, attackAttribute.Crystal, ConvertEffect);

        Attack(10, attackType.Pierce, attackAttribute.Crystal);
    }

    void ConvertEffect()
    {
        if (targetUnit.carryEffects.crystalize.stack >= 5)
        {
            int addCount = 0;
            addCount += targetUnit.attackBoost > 0? targetUnit.attackBoost : 0;
            targetUnit.attackBoost = 0;
            addCount += targetUnit.resistanceBoost > 0? targetUnit.resistanceBoost : 0;
            targetUnit.resistanceBoost = 0;
            targetUnit.resistanceBoost -= addCount;
        }
    }
}
