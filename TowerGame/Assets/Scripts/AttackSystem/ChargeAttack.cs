using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Moveable))]
public class ChargeAttack : AbilityBase
{
    public float speed = 3.0f;
    public float AutoSearchRAG = 4.0f;
    public static float AARange = 0.4f;
    public float ChargeDmg = 1.0f;
    public GameObject AOEPrefab = null;

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
        moveable.MoveSpeed += speed;
    }

    protected override void UpdateWaitEffect()
    {
        Vector3 dirVector = transform.position - NPCinfo.target.transform.position;
        moveable.targetPos = NPCinfo.target.transform.position + (AARange - 0.1f) * dirVector.normalized; ;
    }

    protected override void InstantEffect()
    {
        base.InstantEffect();
        if (AOEPrefab) Instantiate(AOEPrefab, transform);
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
        moveable.MoveSpeed -= speed;
        wait = false;
        moveable.arriveDelegate -= SetWaitFalse;
    }
}
