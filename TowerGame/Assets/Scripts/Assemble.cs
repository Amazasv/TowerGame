using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NPCInfo))]
[RequireComponent(typeof(Moveable))]
public class Assemble : MonoBehaviour
{
    private Vector3 lastPosition = Vector3.zero;
    private NPCInfo NPCinfo = null;
    private AssembleLayout assembleLayout = null;
    private Moveable moveable = null;
    private void Awake()
    {
        UpdateRefference();
        assembleLayout.assembleList.Add(this);
    }

    private void Update()
    {
        if (lastPosition != assembleLayout.transform.position)
        {
            lastPosition = assembleLayout.transform.position;
            NPCinfo.target = null;
            NPCinfo.invincible = true;
            GetComponent<AimBase>().enabled = false;
            moveable.arriveDelegate += SetInvincibleFalse;
        }
        if (NPCinfo.target == null) moveable.targetPos = assembleLayout.GetTargetPoint(this);
    }

    private void SetInvincibleFalse()
    {
        GetComponent<AimBase>().enabled = true;
        NPCinfo.invincible = false;
        moveable.arriveDelegate -= SetInvincibleFalse;
    }


    private void UpdateRefference()
    {
        NPCinfo = GetComponent<NPCInfo>();
        moveable = GetComponent<Moveable>();
        assembleLayout = GetComponentInParent<AssembleLayout>();
    }

    private void OnDestroy()
    {
        assembleLayout.assembleList.RemoveAt(assembleLayout.assembleList.IndexOf(this));
    }

}
