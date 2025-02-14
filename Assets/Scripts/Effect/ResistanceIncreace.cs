using UnityEngine;

public class ResistanseIncrease : Effect
{
    //attackTypeで３つ、attackAttributeで５つ、属性関係なしで1つの合計サイズ9の配列
    public int[] resistanseIncrease = new int[9];

    public override void AddStack(int value, int index)
    {
        resistanseIncrease[index] += value;
    }

    //ターン終了時スタックを消滅
    public override void Trigger()
    {
        for (int i = 0; i < resistanseIncrease.Length; i++)
        {
            resistanseIncrease[i] = 0;
        }
    }
}
