using UnityEngine;

public class ResistanseIncrease : Effect
{
    //attackType�łR�AattackAttribute�łT�A�����֌W�Ȃ���1�̍��v�T�C�Y9�̔z��
    public int[] resistanseIncrease = new int[9];

    public override void AddStack(int value, int index)
    {
        resistanseIncrease[index] += value;
    }

    //�^�[���I�����X�^�b�N������
    public override void Trigger()
    {
        for (int i = 0; i < resistanseIncrease.Length; i++)
        {
            resistanseIncrease[i] = 0;
        }
    }
}
