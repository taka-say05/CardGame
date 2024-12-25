using UnityEngine;

public class Celestine : Card
{
    public override void Use()
    {
        Attack(3, attackType.Impact, attackAttribute.Cold, OnHit);

        for (int i = 0; i < dataBox.enemyUnits.Length; i++)
        {
            if (dataBox.enemyUnits[i] != null)
            {
                if (dataBox.enemyUnits[i] == targetUnit)
                {
                    Attack(10, attackType.Impact, attackAttribute.Cold, null, dataBox.enemyUnits[i]);
                }
                else if (dataBox.enemyUnits[i].carryEffects.freeze.stack <= 0)
                {
                    Attack(10, attackType.Impact, attackAttribute.Cold, null, dataBox.enemyUnits[i]);
                }
            }
        }

        for (int i = 0; i < dataBox.enemyUnits.Length; i++)
        {
            if (dataBox.enemyUnits[i] != null)
            {
                if (dataBox.enemyUnits[i].carryEffects.freeze.stack >= 3)
                {
                    Attack(15, attackType.Impact, attackAttribute.Cold, null, dataBox.enemyUnits[i]);
                    dataBox.enemyUnits[i].carryEffects.freeze.stack = 0;
                }
            }
        }
    }

    private void OnHit()
    {       
        int damage = 0;
        for (int i = 0; i < dataBox.enemyUnits.Length; i++)
        {
            if (dataBox.enemyUnits[i] != null)
            {
                damage += dataBox.enemyUnits[i].carryEffects.freeze.stack;
            }
        }
        Attack(damage, attackType.Impact, attackAttribute.Cold);
        targetUnit.carryEffects.freeze.AddStack(damage);
    }
}
