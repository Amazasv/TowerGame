using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveable : MonoBehaviour
{
    public delegate void ArriveDelegate();
    public ArriveDelegate arriveDelegate;

    public float MoveSpeed = 3f;
    public Vector3 targetPos = Vector3.zero;
    public Vector2 dirVec = Vector2.zero;
    public static float eps = 0.01f;

    private Animator anim = null;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        dirVec = targetPos - transform.position;
        UpdateAnimPara();
        UpdatePosition();
    }

    private void UpdateAnimPara()
    {
        if (anim)
        {
            if (dirVec.magnitude > eps)
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
        if (dirVec.magnitude > eps)
        {
            transform.Translate(dirVec.normalized * MoveSpeed * Time.deltaTime);
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

