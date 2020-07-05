using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Moveable : MonoBehaviour
{

    [SerializeField]
    private float basicMovementSpeed = 0.75f;

    public VoidDelegate arriveDelegate;
    public float speedMult = 1.0f;
    public Vector2 targetPos = Vector2.zero;
    public Vector2 dirVec = Vector2.zero;
    public bool freeze = false;


    private NPCBase NPCbase = null;
    private static float eps = 0.01f;
    private Animator anim = null;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        NPCbase = GetComponent<NPCBase>();
        if (NPCbase) NPCbase.OnDead += delegate { freeze = true; };
        if (NPCbase) NPCbase.OnRespawn += delegate { freeze = false; };
    }

    private void Start()
    {
        //targetPos = transform.position;
    }

    private void Update()
    {
        if (!freeze)
        {
            UpdatePosition();
            UpdateAnimPara();
        }
    }

    private void UpdateAnimPara()
    {
        if (anim)
        {
            if (Vector2.Distance(targetPos, transform.position) > eps)
            {
                anim.SetFloat("Horizontal", dirVec.x);
                anim.SetFloat("Vertical", dirVec.y);
                anim.SetBool("walking", true);
            }
            else anim.SetBool("walking", false);
        }
    }
    private void UpdatePosition()
    {
        if (Vector2.Distance(targetPos, transform.position) > eps)
        {
            Vector2 currentPosition = transform.position;
            dirVec = targetPos - currentPosition;
            transform.Translate(dirVec.normalized * basicMovementSpeed * speedMult * Time.deltaTime);
            CheckArrive();
        }
    }
    private void CheckArrive()
    {
        if (Vector2.Distance(targetPos, transform.position) <= eps)
        {
            transform.position = targetPos;
            arriveDelegate?.Invoke();
        }
    }
}

