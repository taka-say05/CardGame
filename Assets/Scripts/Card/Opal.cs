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

        Attack(20, type, attribute, OnHit);
    }

    private void OnHit()
    {
        targetUnit.boostType[(int)type] -= 10;
        targetUnit.boostAttribute[(int)attribute] -= 10;
    }
}
