using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingArrow : MonoBehaviour
{
    public delegate void Grounded();
    public Grounded grounded;

    public Transform destination = null;
    public float tangent = 4.0f;
    public float hoverTime = 1.5f;


    private Animator anim = null;
    private Vector3 destinationPos = new Vector3();
    private float t = 0.0f;
    private Vector3 origin = Vector3.zero;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        t = 0.0f;
        origin = transform.position;
        anim.speed = (10.0f / 12.0f) / hoverTime;
    }

    private void Update()
    {
        if (destination) destinationPos = destination.position;
        Vector3 dirVec = destinationPos - origin;
        if (anim && dirVec.magnitude > 0.1f)
        {
            anim.SetFloat("Horizontal", dirVec.x);
            anim.SetFloat("Vertical", dirVec.y);
        }
        Vector3 res = new Vector3();
        t += Time.deltaTime;
        res = Vector3.Lerp(origin, destinationPos, t / hoverTime);
        res += (-tangent / hoverTime * t * t + tangent * t) * Vector3.up;
        transform.position = res;
        if (t >= hoverTime)
        {
            if (destination) grounded?.Invoke();
            if (anim) anim.SetBool("Grounded", true);
        }
    }
}
