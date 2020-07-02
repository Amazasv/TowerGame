using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallisticProjectile : MonoBehaviour
{
    public VoidDelegate grounded;
    public Vector2 targetPos = Vector2.zero;
    public float tangent = 0.0f;
    public float speed = 0.0f;

    private Vector2 origin = Vector2.zero;
    private Vector2 dirVec = Vector2.zero;
    private float travelTime = 0.0f;
    private float timer = 0.0f;
    private Animator[] anims = null;
    private void Awake()
    {
        anims = GetComponentsInChildren<Animator>();
    }
    private void Start()
    {
        origin = transform.position;
        dirVec = targetPos - origin;
        travelTime = dirVec.magnitude / speed;
        timer = 0.0f;
        foreach (Animator anim in anims)
            anim.speed = (10.0f / 12.0f) / travelTime;
    }

    private void Update()
    {
        foreach (Animator anim in anims)
            if (dirVec.magnitude > 0.1f)
            {
                anim.SetFloat("Horizontal", dirVec.x);
                anim.SetFloat("Vertical", dirVec.y);
            }
        Vector3 res = new Vector3();

        res = Vector3.Lerp(origin, targetPos, timer / travelTime);
        res += (-tangent / travelTime * timer * timer + tangent * timer) * Vector3.up;
        transform.position = res;

        if (timer < travelTime)
        {
            timer += Time.deltaTime;
            if (timer >= travelTime)
            {
                grounded?.Invoke();
                foreach (Animator anim in anims)
                    anim.SetBool("Grounded", true);
            }
        }
    }


}
