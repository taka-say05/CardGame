using UnityEngine;

public class ResistanceBoost : Effect
{
    //�^�[���J�n���Ăяo���B�X�^�b�N�͂��̎��p�ŁA�����㏸���������ꍇ�͒���unit�̂��������
    public override void Trigger()
    {
        Debug.Log("R_Boost");
        carrierUnit.resistanceBoost += stack;
        BoostText(stack);
        stack = 0;
    }

    //�A�C�R���̐���������p
    public void BoostText(int a)
    {
        //�e�L�X�g�̐������Aa��(�u�[�X�g�����Z����Ƃ���+=��)
    }
}
