using UnityEngine;

public class Crystalize : Effect
{
    public override void Trigger()
    {
        //�����̊T�O������̂��ߌ��
        DecrementStack(2);
    }
}
