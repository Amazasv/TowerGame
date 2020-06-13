using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AimEnemy))]
public class RangerAI : AutoAttack
{
    public EnemyAI target = null;
    //private float AimCD = 0.0f;
    private AimEnemy aimEnemy = null;
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
        UpdateTarget();
        UpdateTryAA(target);
    }


    private void UpdateTarget()
    {
        //if (AimCD <= 0.0f)
        //{
        //    AimCD = 0.5f;
            if (target == null)
            {
                target = aimEnemy.AimTarget("All",AARange);
            }
            else if (Vector3.Distance(target.transform.position, transform.position) > AARange)
            {
                target = null;
            }
        //}
        //else AimCD -= Time.deltaTime;
    }

    private void UpdateReferences()
    {
        aimEnemy = GetComponent<AimEnemy>();
    }
}
