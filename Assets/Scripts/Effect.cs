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
    [SerializeField] GameObject stackText;
    TextMeshPro text;
    int id;

    public void Init(Unit carrierUnit)
    {
        this.carrierUnit = carrierUnit;
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
