using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AutoAttackSystem))]
[RequireComponent(typeof(NPCBase))]
public class AimBase : MonoBehaviour
{
    protected NPCBase NPCinfo = null;
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
        NPCinfo = GetComponent<NPCBase>();
        attackSystem = GetComponent<AutoAttackSystem>();
        center = assembleLayout ? assembleLayout.assemblyPoint : transform;
    }
    virtual protected void TryNewTarget(NPCBase newTarget)
    {
        NPCBase record = NPCinfo.target;
        NPCinfo.target = newTarget;
        if (!attackSystem.CheckAnyCanUse())
        {
            NPCinfo.target = record;
        }
    }
}
