using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(NPCInfo))]
[RequireComponent(typeof(Moveable))]
public class MoveAlongPath : MonoBehaviour
{
    public WayPoints wayPoints = null;
    private Moveable moveable = null;
    private NPCInfo NPCinfo = null;
    private int m_CurrentPoint = 1;

    private void Awake()
    {
        UpdateRefference();
    }

    private void OnEnable()
    {
        moveable.arriveDelegate += NextPoint;
    }

    private void Update()
    {
        if (NPCinfo.target == null)
        {
            moveable.targetPos = wayPoints.pointsPos[m_CurrentPoint];
        }
    }

    private void NextPoint()
    {
        if (m_CurrentPoint < wayPoints.pointsPos.Length - 1)
        {
            if (transform.position == wayPoints.pointsPos[m_CurrentPoint])
                m_CurrentPoint++;
        }
        else Destroy(gameObject);
    }

    private void OnDisable()
    {
        moveable.arriveDelegate -= NextPoint;
    }

    private void UpdateRefference()
    {
        moveable = GetComponent<Moveable>();
        NPCinfo = GetComponent<NPCInfo>();
    }
}
