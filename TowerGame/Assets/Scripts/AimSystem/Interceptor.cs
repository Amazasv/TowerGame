using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Interceptor : AimBase
{
    protected override void UpdateTarget()
    {
        base.UpdateTarget();
        if (NPCinfo.target == null)
        {
            if (CompareTag("Ally")) TryNewTarget(NPCList.NearestAllEnemy(center));
            if (CompareTag("Enemy")) TryNewTarget(NPCList.NearestAllAlly(center));

        }
        else if (NPCinfo.target.target != NPCinfo)
        {
            if (CompareTag("Ally")) TryNewTarget(NPCList.NearestFreeEnemy(center));
            if (CompareTag("Enemy")) TryNewTarget(NPCList.NearestFreeAlly(center));
        }
    }

    protected override void TryNewTarget(NPCInfo newTarget)
    {
        NPCInfo record = NPCinfo.target;
        NPCinfo.target = newTarget;
        if (attackSystem.CheckAnyCanUse())
        {
            if (NPCinfo.target.target == null) NPCinfo.target.target = NPCinfo;
        }
        else NPCinfo.target = record;

    }

}
