using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AutoAttackSystem))]
[RequireComponent(typeof(NPCInfo))]
public class AimBase : MonoBehaviour
{
    protected NPCInfo NPCinfo = null;
    protected AssembleLayout assembleLayout = null;
    protected AutoAttackSystem attackSystem = null;
    protected Transform center = null;
    private void Awake()
    {
        UpdateReferences();
    }

    private void Update()
    {
        UpdateTarget();
    }

    virtual protected void UpdateTarget() 
    {
        if (!attackSystem.CheckAnyCanUse())
        {
            NPCinfo.target = null;
        }
    }

    private void UpdateReferences()
    {
        assembleLayout = GetComponentInParent<AssembleLayout>();
        NPCinfo = GetComponent<NPCInfo>();
        attackSystem = GetComponent<AutoAttackSystem>();
        center = assembleLayout ? assembleLayout.assemblyPoint : transform;
    }
    virtual protected void TryNewTarget(NPCInfo newTarget)
    {
        NPCInfo record = NPCinfo.target;
        NPCinfo.target = newTarget;
        if (!attackSystem.CheckAnyCanUse())
            NPCinfo.target = record;
        
    }
}
