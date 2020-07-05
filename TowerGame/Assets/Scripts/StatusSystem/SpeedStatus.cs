using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpeedStatus : MonoBehaviour
{
    public float duration = 3.0f;
    public float addSpeedMult = 0.0f;

    private Moveable moveable = null;
    private NPCBase NPCbase = null;

    private void Awake()
    {
        moveable = GetComponent<Moveable>();
        if (moveable == null) Destroy(this);
        NPCbase = GetComponent<NPCBase>();
        NPCbase.OnDead += delegate { Destroy(this); };
    }
    private void Start()
    {
        moveable.speedMult += addSpeedMult;
    }
    private void Update()
    {
        if (duration > 0.0f) { duration -= Time.deltaTime; }
        else Destroy(this);
    }
    private void OnDestroy()
    {
        moveable.speedMult -= addSpeedMult;
    }
}
