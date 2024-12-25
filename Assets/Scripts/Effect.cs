using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�^�[���I�����Ƀ��Z�b�g�i�h���[�Ƃ��f�b�L�Ǘ��Ƃ����j

public abstract class Effect : MonoBehaviour
{
    [System.NonSerialized] public int stack = 0;
    [System.NonSerialized] public int boostValue = 0;
    protected Unit carrierUnit;

    public void Init(Unit carrierUnit)
    {
        this.carrierUnit = carrierUnit;
    }


    public void AddStack(int addValue)
    {
        Debug.Log("addStack:" + addValue + this);
        stack += addValue;
    }

    public abstract void Trigger();

}
