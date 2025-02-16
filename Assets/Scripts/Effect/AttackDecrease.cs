using UnityEngine;

public class AttackDecrease : Effect 
{
    //attackTypeで３つ、attackAttributeで５つ、属性関係なしで1つの合計サイズ9の配列
    public int[] attackDecrease = new int[9];
    public override void AddStack(int value, int index)
    {
        attackDecrease[index] += value;
    }

    //ターン終了時スタックを消滅
    public override void Trigger()
    {
        for (int i = 0; i < attackDecrease.Length; i++)
        {
            attackDecrease[i] = 0;
        }
    }
}
