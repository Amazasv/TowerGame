using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rouge : AimBase
{
    protected override void UpdateTarget()
    {
        if (NPCinfo.target == null)
        {
            if (CompareTag("Ally")) TryNewTarget(NPCList.NearestFreeEnemy(transform));
            if (CompareTag("Enemy")) TryNewTarget(NPCList.NearestFreeAlly(transform));
        }
        base.UpdateTarget();
    }
}
