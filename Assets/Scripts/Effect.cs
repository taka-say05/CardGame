using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    public GameObject Init(Unit carrierUnit)
    {
        this.carrierUnit = carrierUnit;
        icon = Instantiate((GameObject)Resources.Load(this.GetType().Name), transform);
        stackText = icon.transform.Find("text").gameObject;
        text = stackText.GetComponent<TextMeshPro>();

        return icon;
    }


    public virtual void AddStack(int value)
    {
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
        text.text = value.ToString();
    }

    protected void DecrementStack(int value)
    {
        stack -= value;
        if (stack <= 0)
        {
            stack = 0;
            carrierUnit.RemoveActiveIcon(icon);
        }
        text.text = stack.ToString();
    }

    public abstract void Trigger();

}
