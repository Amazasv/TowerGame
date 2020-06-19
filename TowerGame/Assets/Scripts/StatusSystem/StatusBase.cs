using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCInfo))]
public class StatusBase : MonoBehaviour
{
    public float duration = 3.0f;
    protected NPCInfo NPCinfo = null;
    virtual protected void StartEffect() { }
    virtual protected void UpdateEffect() { }
    virtual protected void EndEffect() { }

    private void Awake()
    {
        NPCinfo = GetComponent<NPCInfo>();
        NPCinfo.statusList.Add(this);
        StartEffect();
    }

    private void Update()
    {
        if (duration > 0.0f)
        {
            UpdateEffect();
            duration -= Time.deltaTime;
        }
        else Destroy(this);
    }

    private void OnDestroy()
    {
        EndEffect();
        NPCinfo.statusList.Remove(this);
    }

}
