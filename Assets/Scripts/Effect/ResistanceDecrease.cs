using UnityEngine;

public class ResistanceDecrease : Effect
{
    //�^�[���J�n���Ăяo���B�X�^�b�N�͂��̎��p�ŁA�����������������ꍇ�͒���unit�̂��������
    public override void Trigger()
    {
        Debug.Log("Decrease");
        carrierUnit.resistanceBoost -= stack;
        DecreaseText(stack);
        stack = 0;
    }

    //�A�C�R���̐���������p
    public void DecreaseText(int a)
    {
        //�e�L�X�g�̐������Aa��(�u�[�X�g�����Z����Ƃ���+=��)
    }
}
