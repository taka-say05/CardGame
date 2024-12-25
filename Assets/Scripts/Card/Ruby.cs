using UnityEngine;

public class Ruby : Card
{
    public override void Use()
    {
        Attack(5, attackType.Impact, attackAttribute.Physical, GiveBleeding);

        Attack(1, attackType.Impact, attackAttribute.Physical);
        if(targetUnit.hp < (targetUnit.hpMax * 3 / 10))
        {
            targetUnit.carryEffects.bleeding.AddStack(5);
        }
    }

    void GiveBleeding()
    {
        targetUnit.carryEffects.bleeding.AddStack(5);
    }
}
