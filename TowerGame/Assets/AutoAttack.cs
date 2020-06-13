using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : MonoBehaviour
{
    [SerializeField]
    protected float AARange = 0.5f;
    [SerializeField]
    protected float AASpeed = 1.0f;
    [SerializeField]
    protected float AADmg = 1.0f;

    private float CD = 0.0f;

    public void UpdateTryAA(Component target)
    {
        NPCHealth tmp = null;
        if (target) tmp = target.GetComponent<NPCHealth>();
        if (tmp && CD <= 0.0f && Vector3.Distance(transform.position, tmp.transform.position) < AARange)
        {
            CD = AASpeed;
            tmp.DealDmg(AADmg);
        }
        else CD -= Time.deltaTime;
    }
}
