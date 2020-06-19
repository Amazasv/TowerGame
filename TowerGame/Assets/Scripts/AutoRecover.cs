using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(NPCInfo))]
public class AutoRecover : MonoBehaviour
{
    [SerializeField]
    private float recoverRate = 0.5f;
    [SerializeField]
    private float recoverTime = 2.0f;

    private float CD = 2.0f;
    private NPCInfo NPCinfo = null;
    private void Awake()
    {
        NPCinfo = GetComponent<NPCInfo>();
    }

    private void Update()
    {
        if (NPCinfo.target)
        {
            CD = recoverTime;
        }
        else if (CD <= 0.0f)
        {
            NPCinfo.health = Mathf.Clamp(NPCinfo.health + recoverRate * Time.deltaTime, 0, NPCinfo.MaxHealth);
        }
        else
        {
            CD -= Time.deltaTime;
        }
    }

}
