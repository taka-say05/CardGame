using TMPro;
using UnityEngine;

public enum attackType
{
    Slash,
    Impact,
    Pierce
};

public enum attackAttribute
{ 
    Cold,
    Crystal,
    Heat,
    Lightning,
    Physical
}


public class Unit : MonoBehaviour
{
    [SerializeField] GameObject greenBar_pivot = default;
    [SerializeField] TextMeshProUGUI hpText = default;

    public bool player = false;

    public attackType weaknessType;
    public attackAttribute weaknessAttribute;

    public int hp = 50;
    public int speed = 3;
    [System.NonSerialized] public int hpMax = 50;

    [System.NonSerialized] public int attackBoost = 0;
    [System.NonSerialized] public int resistanceBoost = 0;
    [System.NonSerialized] public int[] boostAttribute = new int[5];
    [System.NonSerialized] public int[] boostType = new int[3];
    [System.NonSerialized] public int[] resistanceAttribute = new int[5];
    [System.NonSerialized] public int[] resistanceType = new int[3];

    public struct Effects {
        public AttackBoost attackBoost;
        public AttackDecrease attackDecrease;
        public Bleeding bleeding;
        public Burn burn;
        public Crystallization crystallization;
        public Freeze freeze;
        public Laceration laceration;
        public Poison poison;
        public ResistanceBoost resistanceBoost;
        public ResistanceDecrease resistanceDecrease;
    }

    [System.NonSerialized] public Effects carryEffects;

    // Start is called before the first frame update
    protected void Start()
    {
        hpMax = hp;
        hpText.text = hpMax.ToString();


        carryEffects.attackBoost = gameObject.AddComponent<AttackBoost>();
        carryEffects.attackBoost.Init(this);

        carryEffects.attackDecrease = gameObject.AddComponent<AttackDecrease>();
        carryEffects.attackDecrease.Init(this);

        carryEffects.bleeding = gameObject.AddComponent<Bleeding>();
        carryEffects.bleeding.Init(this);

        carryEffects.crystallization = gameObject.AddComponent<Crystallization>();
        carryEffects.crystallization.Init(this);

        carryEffects.burn = gameObject.AddComponent<Burn>();
        carryEffects.burn.Init(this);

        carryEffects.freeze = gameObject.AddComponent<Freeze>();
        carryEffects.freeze.Init(this);

        carryEffects.laceration = gameObject.AddComponent<Laceration>();
        carryEffects.laceration.Init(this);

        carryEffects.poison = gameObject.AddComponent<Poison>();
        carryEffects.poison.Init(this);

        carryEffects.resistanceBoost = gameObject.AddComponent<ResistanceBoost>();
        carryEffects.resistanceBoost.Init(this);

        carryEffects.resistanceDecrease = gameObject.AddComponent<ResistanceDecrease>();
        carryEffects.resistanceDecrease.Init(this);

        DataBox data = GameObject.FindGameObjectWithTag("DataBox").GetComponent<DataBox>();
        if (player)
        {
            Unit[] units = data.playerUnits;
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i] == null)
                {
                    data.playerUnits[i] = this;
                    break;
                }
            }
        }
        else
        {
            Unit[] units = data.enemyUnits;
            for (int i = 0; i < units.Length; i++)
            {
                if (units[i] == null)
                {
                    data.enemyUnits[i] = this;
                    break;
                }
            }
        }



    }

    public int OnAttack(int damage)
    {
        carryEffects.bleeding.Trigger();
        return damage + attackBoost;
    }

    public bool GetDamage(int damageValue, attackType type, attackAttribute attribute)//未実装箇所あり。ダメージ量アップ
    {
        Debug.Log("Damage");
        if (weaknessType == type)
        {
            damageValue = (int)(damageValue * 1.5f);
        }

        if (weaknessAttribute == attribute)
        {
            damageValue = (int)(damageValue * 1.5f);
        }

        hp -= damageValue;
        Debug.Log("EnemyHP:" + hp);
        greenBar_pivot.transform.localScale = new Vector3(1.0f * hp / hpMax, 1, 1);
        hpText.text = hp.ToString();

        carryEffects.laceration.Trigger();


        //ヒットしたかを判断する部分が未実装
        return true;
    }

    public void EndTrigger()
    {
        attackBoost = 0;
        resistanceBoost = 0;
        //攻撃力増加処理
        carryEffects.attackBoost.Trigger();
        //熱傷効果処理
        carryEffects.burn.Trigger();
        //毒効果処理
        carryEffects.poison.Trigger();
        //結晶化
        carryEffects.crystallization.Trigger();
    }
}
