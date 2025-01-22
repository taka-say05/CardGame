using UnityEngine;

public class Freeze : Effect
{
    public override void Trigger()
    {
        Debug.Log("Freeze");
        //凍結処理。スロットの概念があいまいなため。
        DecrementStack(2);
        Debug.Log(this + "StackCount:" + stack);
    }
}
