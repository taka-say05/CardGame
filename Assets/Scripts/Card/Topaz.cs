using UnityEngine;

//Š„‡‘Ï«‘‰Á‚Á‚Ä‚Ì‚Í’N‚ÉH
public class Topaz : Card
{
    public override void Use()
    {
        Attack(2 * targetUnit.carryEffects.burn.stack, attackType.Impact, attackAttribute.Heat, AddBurn);        

        Attack(8, attackType.Impact, attackAttribute.Heat);

        if (targetUnit.carryEffects.burn.stack >= 10)
        {
            for (int i = 0; i < dataBox.enemyUnits.Length; i++)
            {
                if (dataBox.enemyUnits[i] != null && dataBox.enemyUnits[i] != targetUnit)
                {
                    dataBox.enemyUnits[i].carryEffects.burn.AddStack(targetUnit.carryEffects.burn.stack / 2);
                }
            }
            ownerUnit.resistanceBoost += 20;
        }
    }

    void AddBurn()
    {
        targetUnit.carryEffects.burn.AddStack(5);
    }
}
