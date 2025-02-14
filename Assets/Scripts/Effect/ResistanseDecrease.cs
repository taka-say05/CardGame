using UnityEngine;

public class ResistanseDecrease : Effect
{
    //attackType�łR�AattackAttribute�łT�A�����֌W�Ȃ���1�̍��v�T�C�Y9�̔z��
    public int[] resistanseDecrease = new int[9];

    public override void AddStack(int value, int index)
    {
        resistanseDecrease[index] += value;
    }

    //�^�[���I�����X�^�b�N������
    public override void Trigger()
    {
        for (int i = 0; i < resistanseDecrease.Length; i++)
        {
            resistanseDecrease[i] = 0;
        }
    }
}
