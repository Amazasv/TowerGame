using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AutoAttackSystem))]
[RequireComponent(typeof(NPCInfo))]
public class AbilityBase : MonoBehaviour
{
    public float abilityCD = 0.0f;
    public float attackAnim = 0.3f;
    public float castAnim = 0.0f;
    public int autoCastPriority = 0;



    protected AutoAttackSystem attackSystem = null;
    protected NPCInfo NPCinfo = null;
    protected Animator anim = null;

    protected bool wait = false;
    protected float cd = 0.0f;
    protected float channeling = 0.0f;
    //protected float animating = 0.0f;
    virtual protected void UpdateREF()
    {
        attackSystem = GetComponent<AutoAttackSystem>();
        NPCinfo = GetComponent<NPCInfo>();
        anim = GetComponent<Animator>();
    }
    virtual protected void StartWaitEffect() //用于指示选择目标，这个取名不满意啊啊
    {
        wait = true;
        Invoke("InstantEffect", attackAnim);
    }
    virtual protected void UpdateWaitEffect() //用于鼠标选择目标/接近目标
    {
        wait = false;
    }
    virtual protected void InstantEffect()
    {
        if (anim)
        {
            anim.ResetTrigger("attack");
            anim.SetTrigger("attack");
        }
        if (castAnim > 0.0) channeling = castAnim;
        else EndEffect();
    }
    virtual protected void ChannelingEffect() { }
    virtual protected void EndEffect()
    {
        attackSystem.animating = false;
    }
    virtual public bool CheckTarget() { return true; }
    public bool Use()
    {
        if (cd == 0.0f && CheckTarget())
        {
            cd = abilityCD;
            StartWaitEffect();
            return true;
        }
        return false;
    }

    public void Interrupt()
    {
        CancelInvoke();
        wait = false;
        attackSystem.animating = false;
        channeling = 0.0f;
        EndEffect();
    }


    private void Awake()
    {
        UpdateREF();
    }

    private void OnEnable()
    {
        if (attackSystem.abilityList.Contains(this)) Destroy(this);
        else attackSystem.abilityList.Add(this);
    }

    private void Update()
    {
        cd = Mathf.Clamp(cd - Time.deltaTime, 0.0f, abilityCD);
        if (!CheckTarget()) Interrupt();
        if (wait) UpdateWaitEffect();
        else
        {
            if (channeling > 0.0f)
            {
                channeling -= Time.deltaTime;
                ChannelingEffect();
                if (channeling <= 0.0f)
                {
                    channeling = 0.0f;
                    attackSystem.animating = false;
                    EndEffect();
                }
            }
        }
    }

    private void OnDisable()
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

