using UnityEngine;

public class Freeze : Effect
{
    public override void Trigger()
    {
        Debug.Log("Freeze");
        //���������B�X���b�g�̊T�O�������܂��Ȃ��߁B
        DecrementStack(2);
        Debug.Log(this + "StackCount:" + stack);
    }
}
