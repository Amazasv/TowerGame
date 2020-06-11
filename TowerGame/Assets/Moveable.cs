using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float MoveSpeed = 0.5f;
    [SerializeField]
    private bool m_Arrived = false;
    private Vector3 m_TargetPos = Vector3.zero;

    private void Update()
    {
        Vector3 dir = m_TargetPos - transform.position;
        if (dir.magnitude > 0.1f)
        {
            m_Arrived = false;
            transform.Translate(dir.normalized * MoveSpeed * Time.deltaTime);
        }
        else
        {
            if (m_Arrived == false)
            {
                m_Arrived = true;
                SendMessage("ArriveTargetReciver");
            }
        }
    }
}

