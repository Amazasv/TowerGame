using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NPCBase))]
[RequireComponent(typeof(Moveable))]
public class Assemble : MonoBehaviour
{
    private NPCBase NPCinfo = null;
    private AssembleLayout assembleLayout = null;
    private Moveable moveable = null;
    private AutoAttackSystem autoAttackSystem;
    private AimBase aimBase = null;
    private void Awake()
    {
        UpdateRefference();
        assembleLayout.NPCList.Add(this);
        assembleLayout.OnRelocate += Relocate;
    }

    private void Update()
    {
        if (NPCinfo.target == null) moveable.targetPos = assembleLayout.GetTargetPoint(this);
    }

    private void Relocate()
    {
        if (autoAttackSystem) autoAttackSystem.silence = true;
        if (aimBase) aimBase.enabled = false;
        NPCinfo.target = null;
        NPCinfo.invincible = true;
        moveable.arriveDelegate += SetInvincibleFalse;
    }


    private void SetInvincibleFalse()
    {
        if (autoAttackSystem) autoAttackSystem.silence = false;
        if (aimBase) aimBase.enabled = true;
        NPCinfo.invincible = false;
        NPCinfo.target = null;
        moveable.arriveDelegate -= SetInvincibleFalse;
    }

    private void UpdateRefference()
    {
        NPCinfo = GetComponent<NPCBase>();
        moveable = GetComponent<Moveable>();
        assembleLayout = GetComponentInParent<AssembleLayout>();
        autoAttackSystem = GetComponent<AutoAttackSystem>();
        aimBase = GetComponent<AimBase>();
    }

    private void OnDestroy()
    {
        assembleLayout.NPCList.Remove(this);
        assembleLayout.OnRelocate -= Relocate;
    }

}
