using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedStatus : StatusBase
{
    public float addSpeedMult = 0.0f;

    private Moveable moveable = null;
    protected override void UpdateREF()
    {
        base.UpdateREF();
        moveable = GetComponent<Moveable>();
        if (moveable == null) Destroy(this);
    }

    protected override void StartEffect()
    {
        base.StartEffect();
        moveable.speedMult += addSpeedMult;
    }

    protected override void EndEffect()
    {
        base.EndEffect();
        moveable.speedMult -= addSpeedMult;
    }
}
