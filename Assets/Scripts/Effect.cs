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
    GameObject stackText;
    GameObject icon;
    TextMeshPro text;
    int id;

    public void Init(Unit carrierUnit)
    {
        this.carrierUnit = carrierUnit;
        icon = Instantiate((GameObject)Resources.Load("icon/" + this.GetType().Name), transform);
        stackText = icon.transform.Find("text").gameObject;
        text = stackText.GetComponent<TextMeshPro>();
    }


    public void AddStack(int addValue)
    {
        Debug.Log("addStack:" + addValue + this);
        stack += addValue;
        text.text = addValue.ToString();
    }

    public abstract void Trigger();

}
