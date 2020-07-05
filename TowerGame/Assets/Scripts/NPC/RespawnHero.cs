using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NPCBase))]
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
        NPCinfo.OnDead += StartRespawn;
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
        NPCinfo.invincible = false;
    }

}
