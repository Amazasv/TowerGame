using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private Transform m_WayPoints = null;

    private Moveable m_Moveable = null;

    private void Awake()
    {
        UpdateRefference();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (m_WayPoints)
        {
            m_Moveable.enabled = true;
        }
    }
    private void ArriveTargetReciver()//Called by Moveable SendMessage()
    {

    }
    
    private void UpdateRefference()
    {
        m_Moveable = GetComponent<Moveable>();
    }

    private void UpdateWayPostion()
    {
        
    }
}
