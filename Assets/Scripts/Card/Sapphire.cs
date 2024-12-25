using UnityEngine;

public class Sapphire : Card
{
    int giveValue = 0;
    public override void Use()
    {
        int stackBoost = 0;

        if (targetUnit.carryEffects.laceration.stack >= 5)
        {
            stackBoost = 1;
        }

        giveValue = 3 + stackBoost;
        Attack(4, attackType.Slash, attackAttribute.Cold, OnHit1and2);

        giveValue = 3 + stackBoost;
        Attack(5, attackType.Slash, attackAttribute.Cold, OnHit1and2);

        giveValue = 1 + stackBoost;
        Attack(5, attackType.Slash, attackAttribute.Cold, OnHit3);
    }

    void OnHit1and2()
    {
        targetUnit.carryEffects.laceration.AddStack(giveValue); 
    }

    void OnHit3()
    {
        for (int i = 0; i < 3; i++)
        {
            targetUnit.carryEffects.laceration.AddStack(giveValue);
        }
    }
}
