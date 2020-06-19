using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormAttack : AbilityBase
{
    public float RAG = 4.0f;
    public float DMG = 2.0f;
    public int stormAttackCount = 5;

    private int cnt = 0;

    protected override void InstantEffect()
    {
        base.InstantEffect();
        cnt = stormAttackCount;
    }

    protected override void ChannelingEffect()
    {
        base.ChannelingEffect();
        if (cnt > 0 && channeling <= castAnim / stormAttackCount * cnt)
        {
            cnt--;
            NPCinfo.target.DealDmg(DMG);
        }
    }
    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < RAG);
    }
}
