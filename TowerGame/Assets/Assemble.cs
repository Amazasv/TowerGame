using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class Assemble : MonoBehaviour
{

    public Transform origin = null;

    private Vector3 lastPosition = Vector3.zero;
    private SoliderAI soliderAI = null;
    private RangerAI rangerAI = null;
    private Moveable moveable = null;
    private SwithAI swithAI = null;
    private void Awake()
    {
        UpdateRefference();
        origin = transform;
    }

    private void Update()
    {
        if (lastPosition != origin.position)
        {
            lastPosition = origin.position;
            if (swithAI) swithAI.AImode = SwithAI.AIMode.None;
        }
        if (!CheckTarget()) moveable.targetPos = origin.position;
    }

    private void UpdateRefference()
    {
        soliderAI = GetComponent<SoliderAI>();
        rangerAI = GetComponent<RangerAI>();
        moveable = GetComponent<Moveable>();
        swithAI = GetComponent<SwithAI>();
    }

    private bool CheckTarget()
    {
        if (soliderAI && soliderAI.enabled && soliderAI.target) return true;
        if (rangerAI && rangerAI.enabled && rangerAI.target) return true;
        return false;
    }

}
