using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRangeAttack : AbilityBase
{
    public float AARAG = 4.0f;
    public float AADmg = 1.0f;

    protected override void InstantEffect()
    {
        base.InstantEffect();
        if (NPCinfo.target) NPCinfo.target.DealDmg(AADmg);
    }

    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < AARAG);
    }
}
