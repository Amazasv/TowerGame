using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DMGType
{
    None, Melee, Range
}

public class NPCBase : MonoBehaviour
{
    public NPCBase target = null;
    public string NPCName = "";
    public float MaxHealth = 10.0f;
    [SerializeField]
    private float m_Health = 10.0f;
    public float health
    {
        get { return m_Health; }
        set
        {
            m_Health = Mathf.Clamp(value, 0, MaxHealth);
            if (m_Health == 0) Dead = true;
        }
    }

    [SerializeField]
    private bool m_dead = false;
    public bool Dead
    {
        get { return m_dead; }
        set
        {
            if (m_dead != value)
            {
                if (value)
                {
                    if (invincible) return;
                    OnDead?.Invoke();
                    m_dead = true;
                    NPCdie();
                }
                else
                {
                    m_dead = false;
                    InitializeState();
                    OnRespawn?.Invoke();
                }
            }
        }
    }
    public VoidDelegate OnDead = null;
    public VoidDelegate OnRespawn = null;

    public float armor = 0.0f;
    public float shield = 0.0f;
    public float globalAttackMult = 0.0f;
    public bool invincible = false;
    private Animator anim = null;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (CompareTag("Ally")) NPCList.allies.Add(this);
        if (CompareTag("Enemy")) NPCList.enemys.Add(this);
    }
    private void Start()
    {
        InitializeState();
    }

    private void Update()
    {
        CheckTarget();
    }

    private void InitializeState()
    {
        health = MaxHealth;
    }

    private void NPCdie()
    {
        invincible = true;
        if (anim) anim.SetTrigger("die");
        else Destroy(gameObject);
    }

    public void DealDmg2Target(float value, NPCBase target, DMGType type = DMGType.None)
    {
        if (target) target.SufferDmg(value * (1.0f + globalAttackMult), type);
    }

    public void DealDmg2Target(float value, DMGType type = DMGType.None)
    {
        if (target) target.SufferDmg(value * (1.0f + globalAttackMult), type);
    }
    public void SufferDmg(float value, DMGType type = DMGType.None)
    {
        SendMessageUpwards("GetHit", SendMessageOptions.DontRequireReceiver);
        switch (type)
        {
            case DMGType.None:
                health -= value;
                break;
            case DMGType.Melee:
                health -= value * (1.0f - armor);
                break;
            case DMGType.Range:
                health -= value * (1.0f - shield);
                break;
            default:
                break;
        }
    }
    private void CheckTarget()
    {
        if (target && target.invincible)
        {
            target = null;
        }
    }
    private void OnDestroy()
    {
        if (CompareTag("Ally")) NPCList.allies.Remove(this);
        if (CompareTag("Enemy")) NPCList.enemys.Remove(this);
    }
}
