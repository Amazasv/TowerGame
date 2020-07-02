﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnagerAttack : AbilityBase
{
    public GameObject moganelPrefab = null;
    public GameObject AOEPrefab = null;
    public int cnt = 4;
    public float AADmg = 5.0f;
    public float offsetRadius = 1.0f;
    public float RAG = 4.0f;
    [SerializeField]
    private GameObject cmdCirclePrefab = null;

    private GameObject cmdCircle = null;
    protected override void StartWaitEffect()
    {
        EndWaitEffect();
        base.StartWaitEffect();
    }

    protected override void InstantEffect()
    {
        if (NPCinfo.target)
        {
            for (int i = 0; i < cnt; i++)
            {
                GameObject newProjectile = Instantiate(moganelPrefab, transform.position, Quaternion.identity, transform);
                BallisticProjectile homingArrow = newProjectile.GetComponent<BallisticProjectile>();

                Vector3 offset = new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f);
                offset.Normalize();
                offset *= Random.Range(0.0f, offsetRadius);

                homingArrow.targetPos = NPCinfo.target.transform.position + offset;
                homingArrow.grounded += delegate
                {
                    GameObject AOE = Instantiate(AOEPrefab, homingArrow.transform.position, Quaternion.identity, homingArrow.transform);
                    AOE.GetComponent<AOEInstantDmg>().collisionEvent = InstantDMGDelegate;
                };
            }
        }
        base.InstantEffect();
    }

    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < RAG);
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
    private void InstantDMGDelegate(Collider2D collision)
    {
        NPCBase target = collision.GetComponent<NPCBase>();
        if (target) target.DealDmg(AADmg, DMGType.None);
    }
    public override void ShowIndicator()
    {
        if (cmdCirclePrefab)
        {
            cmdCircle = Instantiate(cmdCirclePrefab, transform);
            cmdCircle.transform.localScale = RAG * 2 * Vector2.one;
        }
    }
    public override void HideIndicator()
    {
        if (cmdCircle) Destroy(cmdCircle);
    }
}