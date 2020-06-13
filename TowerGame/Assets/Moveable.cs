using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public float MoveSpeed = 3f;
    public Vector3 targetPos = Vector3.zero;
    //[SerializeField]
    //private bool m_Arrived = false;

    private void Awake()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        Vector3 dir = targetPos - transform.position;
        dir = new Vector3(dir.x, dir.y, 0.0f);
        if (dir.magnitude > 0.1f)
        {
            transform.Translate(dir.normalized * MoveSpeed * Time.deltaTime);
        }
        else
        {
            SendMessage("ArriveTargetReciver", SendMessageOptions.DontRequireReceiver);
        }
    }
}

