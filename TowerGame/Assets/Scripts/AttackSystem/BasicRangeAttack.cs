using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRangeAttack : AbilityBase
{
    public GameObject arrowPrefab = null;
    public float AARAG = 4.0f;
    public float AADmg = 1.0f;

    protected override void StartWaitEffect()
    {
        EndWaitEffect();
        base.StartWaitEffect();
    }

    protected override void InstantEffect()
    {
        if (NPCinfo.target)
        {
            GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            HomingArrow homingArrow = newArrow.GetComponent<HomingArrow>();
            homingArrow.destination = NPCinfo.target.transform;
            homingArrow.grounded += delegate
            {
                if (NPCinfo.target) NPCinfo.target.DealDmg(AADmg);
            };
        }
        base.InstantEffect();
    }

    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < AARAG);
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
