using UnityEngine;

public class AttackBoost : Effect
{
    //�^�[���J�n���Ăяo���B�X�^�b�N�͂��̎��p�ŁA�����㏸���������ꍇ�͒���unit�̂��������
    public override void Trigger()
    {
        carrierUnit.damageBoost += stack;
        BoostText(stack);
        stack = 0;
    }

    //�A�C�R���̐���������p
    public void BoostText(int a)
    {
        //�e�L�X�g�̐������Aa��(�u�[�X�g�����Z����Ƃ���+=��)
    }
}
