using UnityEngine;

public class Freeze : Effect
{
    public override void Trigger()
    {
        Debug.Log("Freeze");
        //凍結処理。スロットの概念があいまいなため。
        Debug.Log(this + "StackCount:" + stack);
    }
}
