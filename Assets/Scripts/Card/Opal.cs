using UnityEngine;

public class Opal : Card
{
    attackType type;
    attackAttribute attribute;

    public override void Use()
    {
        type = targetUnit.weaknessType;
        attribute = targetUnit.weaknessAttribute;

        Attack(15, type, attribute);

        Attack(20, type, attribute, Hit_2);
    }

    private void Hit_2()
    {
        targetUnit.carryEffects.attackDecrease.AddStack(10, (int)type);
        targetUnit.carryEffects.attackDecrease.AddStack(10, (int)attribute + 3);
    }
}
