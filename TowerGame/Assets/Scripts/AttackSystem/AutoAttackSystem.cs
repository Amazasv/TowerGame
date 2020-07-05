using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackSystem : MonoBehaviour
{
    [SerializeField]
    private bool m_Silence = false;
    public bool silence
    {
        get { return m_Silence; }
        set
        {
            m_Silence = value;
            if (value) InterruptAll();
        }
    }
    public bool autoCast = true;
    public float attackSpeed = 1.0f;
    public bool animating = false;
    public List<AbilityBase> abilityList = new List<AbilityBase>();


    private float m_CD = 0.0f;
    public float cd
    {
        get { return m_CD; }
        set { m_CD = Mathf.Clamp(value, 0.0f, attackSpeed); }
    }


    private NPCBase NPCbase = null;
    private void Awake()
    {
        NPCbase = GetComponent<NPCBase>();
        if (NPCbase) NPCbase.OnDead += delegate { silence = true; };
        if (NPCbase) NPCbase.OnRespawn += delegate { silence = false; };
    }


    private void Start()
    {
        SortAbilities();
    }

    private void Update()
    {
        if (!animating) cd -= Time.deltaTime;
        if (cd == 0.0f && autoCast) UseAbility();
    }

    public void InterruptAll()
    {
        foreach (AbilityBase tmp in abilityList)
            tmp.Interrupt();
    }

    private void UseAbility()
    {
        if (silence) return;
        foreach (AbilityBase tmp in abilityList)
            if (tmp.autoCastPriority >= 0 && tmp.Use())
            {
                cd = attackSpeed;
                animating = true;
                break;
            }
    }

    public bool CheckAnyCanUse()
    {
        foreach (AbilityBase tmp in abilityList)
            if (tmp.autoCastPriority >= 0 && tmp.CheckTarget())
                return true;
        return false;
    }
    private void SortAbilities()
    {
        abilityList.Sort(new ICompareSkill());
    }
}
class ICompareSkill : IComparer<AbilityBase>
{
    public int Compare(AbilityBase x, AbilityBase y)
    {
        return y.autoCastPriority - x.autoCastPriority;
    }
}
