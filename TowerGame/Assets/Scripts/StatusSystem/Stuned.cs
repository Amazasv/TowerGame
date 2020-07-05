using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuned : MonoBehaviour
{
    public float duration = 3.0f;
    private Moveable moveable = null;
    private AutoAttackSystem autoAttackSystem = null;
    private NPCBase NPCbase = null;
    private void Awake()
    {
        moveable = GetComponent<Moveable>();
        autoAttackSystem = GetComponent<AutoAttackSystem>();
        NPCbase = GetComponent<NPCBase>();
        NPCbase.OnDead += delegate { Destroy(this); };
    }
    private void Update()
    {
        if (duration > 0.0f) { duration -= Time.deltaTime; }
        else Destroy(this);
    }
    private void Start()
    {
        if (autoAttackSystem) autoAttackSystem.silence = true;
        if (moveable) moveable.freeze = true;
    }

    private void OnDestroy()
    {
        if (autoAttackSystem) autoAttackSystem.silence = false;
        if (moveable) moveable.freeze = false;
    }
}
