using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burning : StatusBase
{
    public float dps = 4.0f;

    protected override void UpdateEffect()
    {
        base.UpdateEffect();
        NPCinfo.health -= dps * Time.deltaTime;
    }
}
