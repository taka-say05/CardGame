using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public enum state
{
    deck,
    hand,
    trush,
    use,
    reset
};

public abstract class Card : MonoBehaviour
{
    //実際の処理を行うためのコード
    protected Unit targetUnit;//UI側から代入
    protected DataBox dataBox;

    //ダメージ処理はユニットの関数を呼び出して行う



    //UI関係のコード
    [SerializeField] SpriteRenderer full_renderer;
    [SerializeField] GameObject arrowPrefab;

    [System.NonSerialized] public bool slot_set_ready = true;//マウスが離されているか(=スロットにセットしていいか)
    [System.NonSerialized] public bool slot_set = false;//スロットに重なっているか(=スロットにセットされようとしているか)
    [System.NonSerialized] public Vector2 default_position;

    Vector2 default_scale;
    [System.NonSerialized] public BoxCollider2D bc;
    [System.NonSerialized] public Rigidbody2D rb;

    [System.NonSerialized] public SortingGroup sortingGroup;
    GameObject arrowInstance;
    Arrow arrow;
    protected Unit ownerUnit;
    
    protected void Awake()
    {
        default_scale = transform.localScale;
        bc = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        sortingGroup = GetComponent<SortingGroup>();
        if (dataBox == null)
        {
            dataBox = GameObject.FindWithTag("DataBox").GetComponent<DataBox>();
        }
    }

    protected void Update()
    {
        if (slot_set && slot_set_ready)
        {
            full_renderer.enabled = false;
            transform.localScale = default_scale * 0.5f;
        }
        else
        {
            targetUnit = null;
            full_renderer.enabled = true;
            transform.localScale = default_scale;
        }

        if (arrow != null)
        {
            if (arrow.targetUnit != null)
            {
                if (targetUnit == null)
                {
                    Debug.Log("lockOn");
                    targetUnit = arrow.targetUnit;
                }
            }
            else
            {
                targetUnit = null;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Slot" && slot_set_ready)
        {
            transform.position = collision.gameObject.transform.position;
            if(arrow == null)
            {
                arrowInstance = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
                arrow = arrowInstance.GetComponentInChildren<Arrow>();
                ownerUnit = collision.gameObject.GetComponent<Slot>().ownerUnit;
            }
        }
    }

    private void OnMouseDrag()
    {
        slot_set_ready = false;
        Vector3 thisPosition = Input.mousePosition;
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(thisPosition);
        worldPosition.z = 0f;
        transform.position = worldPosition;
    }

    private void OnMouseUp()
    {
        slot_set_ready = true;
        if (slot_set == false)
        {
            dataBox.StateChange(this, state.reset);
        }
        else
        {
            dataBox.addUsingCards(this);
        }
    }

    public abstract void Use();

    public virtual void OnTurnStart()
    {

    }

    protected void Attack(int damageValue, attackType type, attackAttribute attribute, Action onHit = null, Unit target = null)
    {
        damageValue = ownerUnit.OnAttack(damageValue);

        target ??= targetUnit;

        if (target.GetDamage(damageValue, type, attribute) == true)
        {
            if(onHit != null) 
            { 
                onHit();
            }
        }
    }

    public virtual void OnTurnEnd()
    {
        dataBox.StateChange(this, state.use);
        Destroy(arrowInstance);
    }
}
