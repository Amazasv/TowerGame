using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEBase : MonoBehaviour
{
    public static float minnDuration = 0.1f;

    [SerializeField]
    protected float duratioin = 0.0f;
    virtual public void InstantEffect(Collider2D collision) { }
    virtual public void StayEffect(Collider2D collision) { }
    virtual public void ExitEffect(Collider2D collision) { }
    virtual public bool CheckTarget(Collider2D collision) { return true; }
    private void Awake()
    {
        duratioin = Mathf.Max(duratioin, minnDuration);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CheckTarget(collision)) InstantEffect(collision);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CheckTarget(collision)) StayEffect(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CheckTarget(collision)) ExitEffect(collision);
    }

    private void LateUpdate()
    {
        if (duratioin > 0.0f) duratioin -= Time.deltaTime;
        else Destroy(this.gameObject);
    }

}
