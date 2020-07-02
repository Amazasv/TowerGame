using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CollisionEvent(Collider2D collision);
public class AOEBase : MonoBehaviour
{
    public static float minnDuration = 0.1f;

    [SerializeField]
    protected float duratioin = 0.0f;
    public CollisionEvent OnEnter;
    public CollisionEvent OnStay;
    public CollisionEvent OnExit;
    private void Start()
    {
        duratioin = Mathf.Max(duratioin, minnDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnter?.Invoke(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        OnStay?.Invoke(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        OnExit?.Invoke(collision);
    }

    private void LateUpdate()
    {
        if (duratioin > 0.0f) duratioin -= Time.deltaTime;
        else Destroy(this.gameObject);
    }

}
