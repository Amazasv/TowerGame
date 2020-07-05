using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Moveable))]
public class BasicMeleeAttack : AbilityBase
{
    public static float AARange = 0.4f;
    public float AADmg = 1.0f;
    public float RAG = 4.0f;
    [SerializeField]
    private GameObject cmdCirclePrefab = null;
    [SerializeField]
    private bool passive = false;
    private Moveable moveable = null;
    private GameObject cmdCircle = null;
    protected override void UpdateREF()
    {
        base.UpdateREF();
        moveable = GetComponent<Moveable>();
    }

    protected override void UpdateWaitEffect()
    {
        Vector3 dirVector = transform.position - NPCinfo.target.transform.position;
        if (!passive) moveable.targetPos = NPCinfo.target.transform.position;
        if (dirVector.magnitude <= AARange - 0.1f)
        {
            moveable.targetPos = transform.position;
            EndWaitEffect();
        }
    }

    protected override void InstantEffect()
    {
        NPCinfo.DealDmg2Target(AADmg, DMGType.Melee);
        base.InstantEffect();
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
