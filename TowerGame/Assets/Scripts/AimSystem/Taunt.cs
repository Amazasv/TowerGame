﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taunt : AimBase
{
    protected override void UpdateTarget()
    {
        base.UpdateTarget();
        if (CompareTag("Ally")) TryNewTarget(NPCList.NearestAllEnemy(center));
        if (CompareTag("Enemy")) TryNewTarget(NPCList.NearestAllAlly(center));
    }

    protected override void TryNewTarget(NPCBase newTarget)
    {
        NPCBase record = NPCinfo.target;
        NPCinfo.target = newTarget;
        if (attackSystem.CheckAnyCanUse())
        {
            if (NPCinfo.target.target == null) NPCinfo.target.target = NPCinfo;
        }
        NPCinfo.target = record;
    }
}