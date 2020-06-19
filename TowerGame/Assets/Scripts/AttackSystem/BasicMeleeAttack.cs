﻿using System.Collections;
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

    protected override void StartWaitEffect()
    {
        base.StartWaitEffect();
        moveable.arriveDelegate += SetWaitFalse;
    }

    protected override void UpdateWaitEffect()
    {
        Vector3 offset = AARange * (NPCinfo.target.GetComponent<Moveable>().dirHor == Moveable.Direction.left ? Vector2.left : Vector2.right);
        moveable.targetPos = NPCinfo.target.transform.position + offset;
    }

    protected override void InstantEffect()
    {

        base.InstantEffect();
        if (NPCinfo.target) NPCinfo.target.DealDmg(AADmg);
    }

    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < AutoSearchRAG);
    }

    protected override void EndEffect()
    {
        base.EndEffect();
    }

    public void SetWaitFalse()
    {
        wait = false;
        moveable.arriveDelegate -= SetWaitFalse;
    }
}
