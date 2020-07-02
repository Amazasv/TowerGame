using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(NPCBase))]
public class AutoRecover : MonoBehaviour
{
    [SerializeField]
    private float recoverRate = 0.2f;
    [SerializeField]
    private float recoverTime = 5.0f;

    private float CD = 5.0f;
    private NPCBase NPCinfo = null;
    private void Awake()
    {
        NPCinfo = GetComponent<NPCBase>();
    }

    private void Update()
    {
        if (NPCinfo.target)
        {
            CD = recoverTime;
        }
        else if (CD <= 0.0f)
        {
            if (NPCinfo.invincible) return;
            NPCinfo.health += recoverRate * Time.deltaTime * NPCinfo.MaxHealth;
        }
        else
        {
            CD -= Time.deltaTime;
        }
    }

    public void GetHit()
    {
        CD = recoverTime;
    }
}
