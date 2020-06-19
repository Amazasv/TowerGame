using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAA : AbilityBase
{
    public float AARange = 0.4f;
    public float AADmg = 1.0f;

    protected override void InstantEffect()
    {
        base.InstantEffect();
        NPCinfo.target.DealDmg(AADmg);
        Burning burning = NPCinfo.target.gameObject.AddComponent<Burning>();
        burning.duration = 3.0f;
        burning.dps = 3.0f;
    }

    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < AARange);
    }


}
