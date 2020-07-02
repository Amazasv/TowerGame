using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAA : AbilityBase
{
    public GameObject arrowPrefab = null;
    public float AADmg = 1.0f;
    public float FireDuration = 3.0f;
    public float FireDPS = 3.0f;
    public float RAG = 4.0f;
    [SerializeField]
    private GameObject cmdCirclePrefab = null;


    private GameObject cmdCircle = null;
    protected override void StartWaitEffect()
    {
        EndWaitEffect();
        base.StartWaitEffect();
    }
    protected override void InstantEffect()
    {
        base.InstantEffect();
        if (NPCinfo.target)
        {
            GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
            HomingArrow homingArrow = newArrow.GetComponent<HomingArrow>();
            homingArrow.destination = NPCinfo.target.transform;
            homingArrow.grounded += delegate
            {
                if (NPCinfo.target)
                {
                    NPCinfo.target.DealDmg(AADmg);
                    Burning burning = NPCinfo.target.gameObject.AddComponent<Burning>();
                    burning.duration = FireDuration;
                    burning.dps = FireDPS;
                }
            };
        }
    }
    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < RAG);
    }
    protected override void EndWaitEffect()
    {
        if (anim)
        {
            anim.SetFloat("Horizontal", (NPCinfo.target.transform.position - transform.position).x);
            anim.SetFloat("Vertical", (NPCinfo.target.transform.position - transform.position).y);
        }
        base.EndWaitEffect();
    }
    public override void ShowIndicator()
    {
        if (cmdCirclePrefab)
        {
            cmdCircle = Instantiate(cmdCirclePrefab, transform);
            cmdCircle.transform.localScale = RAG * 2 * Vector2.one;
        }
    }
    public override void HideIndicator()
    {
        if (cmdCircle) Destroy(cmdCircle);
    }
}
