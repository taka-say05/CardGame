using UnityEngine;

public class ResistanceDecrease : Effect
{
    //ターン開始時呼び出す。スタックはその時用で、即時減少させたい場合は直接unitのやつをいじる
    public override void Trigger()
    {
        Debug.Log("Decrease");
        carrierUnit.resistanceBoost -= stack;
        DecreaseText(stack);
        stack = 0;
    }

    //アイコンの数字いじる用
    public void DecreaseText(int a)
    {
        //テキストの数字を、aに(ブーストを加算するときは+=で)
    }
}
