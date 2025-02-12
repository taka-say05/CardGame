using UnityEngine;

public class AttackBoost : Effect
{
    //ターン開始時呼び出す。スタックはその時用で、即時上昇させたい場合は直接unitのやつをいじる
    public override void Trigger()
    {
        carrierUnit.damageBoost += stack;
        BoostText(stack);
        stack = 0;
    }

    //アイコンの数字いじる用
    public void BoostText(int a)
    {
        //テキストの数字を、aに(ブーストを加算するときは+=で)
    }
}
