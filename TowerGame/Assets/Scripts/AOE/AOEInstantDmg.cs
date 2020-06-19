using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEInstantDmg : AOEBase
{
    public float Dmg = 3.0f;
    public override bool CheckTarget(Collider2D collision)
    {
        return collision.CompareTag("Enemy");
    }

    public override void InstantEffect(Collider2D collision)
    {
        base.InstantEffect(collision);
        NPCInfo target=collision.GetComponent<NPCInfo>();
        if (target) target.health -= Dmg;
    }
}
