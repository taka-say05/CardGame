using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Fluctuation : Effect
{
    //attackTypeで３つ、attackAttributeで５つ、属性関係なしで1つの合計サイズ9の配列
    public new int[] stack = new int[9];
    public new GameObject[] icon = new GameObject[9];

    TextMeshPro[] texts;

    string[] iconNames = {"Slash","Impact","Pierce","Cold","Crystal","Heat","Lightning","Phycical","" };

    public GameObject[] InitList(Unit carrierUnit)
    {
        this.carrierUnit = carrierUnit;
        for (int i = 0; i < icon.Length; i++)
        {
            icon[i] = Instantiate((GameObject)Resources.Load(this.GetType().Name + "_" + iconNames[i]), transform);
            stackText = icon[i].transform.Find("text").gameObject;
            texts[i] = stackText.GetComponent<TextMeshPro>();
        }

        return icon;
    }

    public override void Trigger()
    {
        for (int i = 0; i < stack.Length; i++)
        {
            stack[i] = 0;
        }
    }

    public override void AddStack(int value, int index)
    {
        stack[index] += value;
        if (stack[index] <= 0)
        {
            stack[index] = 0;
            carrierUnit.RemoveActiveIcon(icon[index]);
        }
        else
        {
            carrierUnit.AddActiveIcon(icon[index]);
        }
        texts[index].text = stack[index].ToString();
    }

    public override void DecrementStack(int value, int index, bool zero = false)
    {
        if (zero)
        {
            stack[index] = 0;
            carrierUnit.RemoveActiveIcon(icon[index]);
            texts[index].text = stack[index].ToString();
        }
        else
        {
            stack[index] -= value;
            if (stack[index] <= 0)
            {
                stack[index] = 0;
                carrierUnit.RemoveActiveIcon(icon[index]);
            }
            texts[index].text = stack[index].ToString();
        }
    }
}
