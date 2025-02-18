using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.XR;
using UnityEngine;

//ターン終了時にリセット（ドローとかデッキ管理とかも）

public abstract class Effect : MonoBehaviour
{
    [System.NonSerialized] public int stack = 0;
    [System.NonSerialized] public int boostValue = 0;
    protected Unit carrierUnit;
    protected GameObject stackText;
    protected GameObject icon;
    TextMeshPro text;

    public virtual GameObject Init(Unit carrierUnit)
    {
        this.carrierUnit = carrierUnit;
        icon = Instantiate((GameObject)Resources.Load(this.GetType().Name), transform);
        stackText = icon.transform.Find("text").gameObject;
        text = stackText.GetComponent<TextMeshPro>();

        return icon;
    }


    public virtual void AddStack(int value, int index = 999)
    {
        //ここを変更時は、攻撃威力や耐性の増加効果のほうも変更
        stack += value;
        if (stack <= 0)
        {
            stack = 0;
            carrierUnit.RemoveActiveIcon(icon);
        }
        else
        {
            carrierUnit.AddActiveIcon(icon);
        }
        text.text = stack.ToString();
    }

    public virtual void DecrementStack(int value, int index = 999, bool zero = false)
    {
        //ここを変更時は、攻撃威力や耐性の増加効果のほうも変更
        if (zero)
        {
            stack = 0;
            carrierUnit.RemoveActiveIcon(icon);
            text.text = stack.ToString();
        }
        else
        {
            if (index == 999)
            {
                stack -= value;
                if (stack <= 0)
                {
                    stack = 0;
                    carrierUnit.RemoveActiveIcon(icon);
                }
                text.text = stack.ToString();
            }
        }
    }

    public abstract void Trigger();

}
