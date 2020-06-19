using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Warrior : AimBase
{
    protected override void UpdateTarget()
    {
        if (NPCinfo.target == null)
        {
            if (CompareTag("Ally")) TryNewTarget(NPCList.NearestAllEnemy(transform));
            if (CompareTag("Enemy")) TryNewTarget(NPCList.NearestAllAlly(transform));
        }
        base.UpdateTarget();
    }
}
