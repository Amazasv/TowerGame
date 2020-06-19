using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttackSystem : MonoBehaviour
{
    public float attackSpeed = 1.0f;
    public bool animating = false;
    public List<AbilityBase> abilityList = new List<AbilityBase>();

    private float cd = 0.0f;

    private void Start()
    {
        SortAbilities();
    }

    private void Update()
    {
        if (cd > 0.0f)
        {
            if (!animating) cd -= Time.deltaTime;
        }
        else
        {
            UseAbility();
        }
    }

    private void UseAbility()
    {
        foreach (AbilityBase tmp in abilityList)
            if (tmp.autoCastPriority >= 0 && tmp.Use())
            {
                cd = attackSpeed;
                animating = true;
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
