using UnityEngine;

public class Spinel : Card
{
    public override void Use()
    {
        FirstAttack();
    }

    private void FirstAttack()
    {
        if (targetUnit.carryEffects.burn.stack >= 5 && targetUnit.carryEffects.burn.stack >= 5)
        {
            Attack(7, attackType.Impact, attackAttribute.Heat);
        }
    }
}
