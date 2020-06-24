using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class BasicMeleeAttack : AbilityBase
{
    public float AutoSearchRAG = 2.0f;
    public static float AARange = 0.4f;
    public float AADmg = 1.0f;

    protected Moveable moveable = null;
    protected override void UpdateREF()
    {
        base.UpdateREF();
        moveable = GetComponent<Moveable>();
    }

    protected override void UpdateWaitEffect()
    {
        Vector3 dirVector = transform.position - NPCinfo.target.transform.position;
        moveable.targetPos = NPCinfo.target.transform.position;
        if (dirVector.magnitude <= AARange - 0.1f)
        {
            moveable.targetPos = transform.position;
            EndWaitEffect();
        }
    }

    protected override void InstantEffect()
    {
        if (NPCinfo.target) NPCinfo.target.DealDmg(AADmg);
        base.InstantEffect();
    }

    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < AutoSearchRAG);
    }

    protected override void EndWaitEffect()
    {
        if (anim)
        {
            anim.SetFloat("Horizontal", (NPCinfo.target.transform.position - transform.position).x);
            anim.SetFloat("Vertical", (NPCinfo.target.transform.position - transform.position).y);
        }
        base.EndWaitEffect();
    }
}
