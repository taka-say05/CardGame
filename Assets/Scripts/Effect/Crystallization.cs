using UnityEngine;

public class Crystallization : Effect
{
    public override void Trigger()
    {
        Debug.Log("Crystallization");
        //�����̊T�O������̂��ߌ��
        stack -= 2;
        Debug.Log(this + "StackCount:" + stack);
    }
}
