﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AutoAttackSystem))]
[RequireComponent(typeof(NPCInfo))]
public abstract class AbilityBase : MonoBehaviour
{
    public float abilityCD = 0.0f;
    public float attackAnim = 0.3f;
    public float castAnim = 0.0f;
    public int autoCastPriority = 0;



    protected AutoAttackSystem attackSystem = null;
    protected NPCInfo NPCinfo = null;
    protected Animator anim = null;

    protected delegate void UpdateFunc();
    protected UpdateFunc updateFunc;

    protected float cd = 0.0f;
    protected float channeling = 0.0f;
    //protected float animating = 0.0f;
    virtual protected void UpdateREF()
    {
        attackSystem = GetComponent<AutoAttackSystem>();
        NPCinfo = GetComponent<NPCInfo>();
        anim = GetComponent<Animator>();
    }
    virtual protected void StartWaitEffect() { }//用于指示选择目标，这个取名不满意啊啊
    virtual protected void UpdateWaitEffect() { } //用于鼠标选择目标/接近目标
    virtual protected void EndWaitEffect()
    {
        Invoke("InstantEffect", attackAnim);
        updateFunc = null;
    }

    virtual protected void InstantEffect()
    {
        if (anim)
        {
            anim.ResetTrigger("attack");
            anim.SetTrigger("attack");
        }
        if (castAnim > 0.0)
        {
            channeling = castAnim;
            updateFunc = ChannelingEffect;
        }
        else Interrupt();
    }
    virtual protected void ChannelingEffect() { }
    virtual protected void EndEffect() { }
    abstract public bool CheckTarget();
    public bool Use()
    {
        if (cd == 0.0f && CheckTarget())
        {
            cd = abilityCD;
            StartWaitEffect();
            updateFunc = UpdateWaitEffect;
            return true;
        }
        return false;
    }

    public void Interrupt()
    {
        updateFunc = null;
        CancelInvoke();
        attackSystem.animating = false;
        EndEffect();
    }
    

    private void Awake()
    {
        UpdateREF();
        if (attackSystem.abilityList.Contains(this)) Destroy(this);
        else attackSystem.abilityList.Add(this);
    }

    private void Update()
    {
        cd = Mathf.Clamp(cd - Time.deltaTime, 0.0f, abilityCD);
        if (updateFunc != null)
        {
            if (!CheckTarget()) Interrupt();
            updateFunc?.Invoke();
        }
    }

    private void OnDestroy()
    {
        attackSystem.abilityList.Remove(this);
    }
}
class ICompareSkill : IComparer<AbilityBase>
{
    public int Compare(AbilityBase x, AbilityBase y)
    {
        return y.autoCastPriority - x.autoCastPriority;
    }
}

