using UnityEngine;

public class AttackIncrease : Effect
{
    //attackType�łR�AattackAttribute�łT�A�����֌W�Ȃ���1�̍��v�T�C�Y9�̔z��
    public int[] attackIncrease = new int[9];
    public override void AddStack(int value, int index)
    {
        attackIncrease[index] += value;
    }

    //�^�[���I�����X�^�b�N������
    public override void Trigger()
    {
        for (int i = 0; i < attackIncrease.Length; i++)
        {
            attackIncrease[i] = 0;
        }
    }
}
