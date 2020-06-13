using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Moveable))]
public class EnemyAI : AutoAttack
{
    private SoliderAI m_Target = null;
    public SoliderAI target
    {
        get { return m_Target; }
        set
        {
            m_Target = value;
            if (value)
            {
                m_Moveable.enabled = false;
                gameObject.tag = "Intercepted";
            }
            else
            {
                m_Moveable.enabled = true;
                gameObject.tag = "Default";
            }
        }
    }
    public WayPoints wayPoints = null;
    private Moveable m_Moveable = null;
    private int m_CurrentPoint = 0;
    private void Awake()
    {
        UpdateRefference();
    }

    void Start()
    {
        if (wayPoints && wayPoints.pointsPos.Length > 0)
        {
            m_CurrentPoint = 0;
            m_Moveable.enabled = true;
            m_Moveable.targetPos = wayPoints.pointsPos[m_CurrentPoint++];
        }
    }

    private void Update()
    {
        UpdateTryAA(target);
    }

    private void ArriveTargetReciver()//Called by Moveable SendMessage()
    {
        if (m_CurrentPoint < wayPoints.pointsPos.Length)
        {
            m_Moveable.targetPos = wayPoints.pointsPos[m_CurrentPoint++];
        }
        else Destroy(gameObject);
    }

    private void UpdateRefference()
    {
        m_Moveable = GetComponent<Moveable>();
    }

    private void OnDestroy()
    {
        if (target)
        {
            target.target = null;
        }
    }
}
