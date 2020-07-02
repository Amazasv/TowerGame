using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingArrow : MonoBehaviour
{
    public VoidDelegate grounded;

    public Transform destination = null;
    public float tangent = 4.0f;
    public float speed = 3.0f;


    private Animator[] anims = null;
    private Vector2 destinationPos = new Vector3();
    private Vector2 origin = Vector3.zero;
    private float t = 0.0f;
    private float hoverTime = 0.0f;
    private void Awake()
    {
        anims = GetComponentsInChildren<Animator>();
    }
    private void Start()
    {
        t = 0.0f;
        origin = transform.position;
        hoverTime = Vector2.Distance(destinationPos, origin) / speed;
        foreach (Animator anim in anims)
            anim.speed = (10.0f / 12.0f) / hoverTime;
    }

    private void Update()
    {
        if (destination) destinationPos = destination.position;
        Vector2 dirVec = destinationPos - origin;
        foreach (Animator anim in anims)
            if (dirVec.magnitude > 0.1f)
            {
                anim.SetFloat("Horizontal", dirVec.x);
                anim.SetFloat("Vertical", dirVec.y);
            }
        t += Time.deltaTime;
        Vector2 res = Vector3.Lerp(origin, destinationPos, t / hoverTime);
        res += (-tangent / hoverTime * t * t + tangent * t) * Vector2.up;
        transform.position = res;
        if (t >= hoverTime)
        {
            if (destination) grounded?.Invoke();
            foreach (Animator anim in anims)
                anim.SetBool("Grounded", true);
        }
    }
}
