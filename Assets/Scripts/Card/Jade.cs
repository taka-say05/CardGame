using UnityEngine;

//å„Ç≈çÏÇÎÇ§
public class Jade : Card
{
    public override void OnTurnStart()
    {
        targetUnit.carryEffects.attackDecrease.AddStack(75);

        base.OnTurnStart();
    }

    public override void Use()
    {
        FirstAttack();
    }

    void FirstAttack()
    {
        Attack(1, attackType.Impact, attackAttribute.Crystal, Hit_1);
        targetUnit.carryEffects.crystalize.AddStack(5);
    }

    void Hit_1()
    {

    }
}
