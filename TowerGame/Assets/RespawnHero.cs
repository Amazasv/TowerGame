using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnHero : MonoBehaviour
{
    [SerializeField]
    private float respawnTime = 20.0f;

    private Animator anim = null;
    private NPCBase NPCinfo = null;
    private void Awake()
    {
        NPCinfo = GetComponent<NPCBase>();
        anim = GetComponent<Animator>();
    }
    public void StartRespawn()
    {
        CancelInvoke();
        Invoke("Respawn", respawnTime);
    }

    private void Respawn()
    {
        if (anim) anim.SetTrigger("respawn");
        NPCinfo.Dead = false;
    }

}
