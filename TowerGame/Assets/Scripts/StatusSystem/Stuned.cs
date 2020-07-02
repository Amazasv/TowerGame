using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuned : StatusBase
{
    private AimBase aimBase = null;
    private Moveable moveable = null;
    private AutoAttackSystem autoAttackSystem = null;
    protected override void UpdateREF()
    {
        base.UpdateREF();
        aimBase = GetComponent<AimBase>();
        moveable = GetComponent<Moveable>();
        autoAttackSystem = GetComponent<AutoAttackSystem>();
    }

    protected override void StartEffect()
    {
        base.StartEffect();
        if (autoAttackSystem) autoAttackSystem.silence = true;
        if (moveable) moveable.freeze = true;
    }

    protected override void EndEffect()
    {
        base.EndEffect();
        if (autoAttackSystem) autoAttackSystem.silence = false;
        if (moveable) moveable.freeze = false;
    }
}
