using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Burning : MonoBehaviour
{
    public float duration = 3.0f;
    public float dps = 4.0f;
    private NPCBase NPCbase = null;
    private void Awake()
    {
        NPCbase = GetComponent<NPCBase>();
        if (NPCbase == null) Destroy(this);
        NPCbase.OnDead += delegate { Destroy(this); };
    }

    private void Update()
    {
        if (duration > 0.0f) { duration -= Time.deltaTime; }
        else Destroy(this);
        Burn();
    }

    private void Burn()
    {
        NPCbase.SufferDmg(dps * Time.deltaTime);
    }
}
