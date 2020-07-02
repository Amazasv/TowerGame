using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCBase))]
public class StatusBase : MonoBehaviour
{
    public float duration = 3.0f;
    protected NPCBase NPCinfo = null;
    virtual protected void StartEffect() { }
    virtual protected void UpdateEffect() { }
    virtual protected void EndEffect() { }
    virtual protected void UpdateREF()
    {
        NPCinfo = GetComponent<NPCBase>();
    }

    private void Awake()
    {
        UpdateREF();
        NPCinfo.statusList.Add(this);
    }

    private void Start()
    {
        StartEffect();
    }

    private void Update()
    {

        if (duration > 0.0f)
        {
            duration -= Time.deltaTime;
            if (!NPCinfo.invincible) UpdateEffect();
        }
        else Destroy(this);
    }

    private void OnDestroy()
    {
        EndEffect();
        NPCinfo.statusList.Remove(this);
    }

}
