using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AimEnemy))]
[RequireComponent(typeof(NPCHealth))]
[RequireComponent(typeof(Moveable))]
public class SoliderAI : AutoAttack
{
    public float searchRange = 3.0f;

    public EnemyAI target = null;
    //private float AimCD = 0.0f;

    private AimEnemy aimEnemy = null;
    private Moveable moveable = null;
    private void Awake()
    {
        UpdateReferences();
    }

    private void OnEnable()
    {
        UpdateTarget();
    }

    private void Update()
    {
        UpdateMoveTarget();
        UpdateTarget();
        UpdateTryAA(target);
    }

    private void UpdateMoveTarget()
    {
        if (target) moveable.targetPos = target.transform.position;
    }


    private void UpdateTarget()
    {
        //if (AimCD <= 0.0f)
        //{
        //    AimCD = 0.5f;
        if (target == null)
        {
            EnemyAI tmp = aimEnemy.AimTarget("All", searchRange);
            target = tmp;
            if (tmp && tmp.CompareTag("Default")) tmp.target = this;
        }
        else if (target.target != this)
        {
            EnemyAI tmp = aimEnemy.AimTarget("Default", searchRange);
            if (tmp)
            {
                target = tmp;
                tmp.target = this;
            }
        }
        else if (Vector3.Distance(target.transform.position, transform.position) > searchRange)
        {
            target = null;
        }
        //}
        //else AimCD -= Time.deltaTime;
    }

    private void UpdateReferences()
    {
        aimEnemy = GetComponent<AimEnemy>();
        moveable = GetComponent<Moveable>();
    }

    private void OnDestroy()
    {
        if (target) target.target = null;
    }
    private void OnDisable()
    {
        if (target) target.target = null;
    }

}
