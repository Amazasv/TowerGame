using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackSystem : MonoBehaviour
{
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
    private void Start()
    {
        SortAbilities();
    }

    private void Update()
    {
        if (!animating) cd -= Time.deltaTime;
        if (cd == 0.0f && autoCast) UseAbility();
    }

    private void UseAbility()
    {
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
