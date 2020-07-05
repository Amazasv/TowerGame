using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttack : AbilityBase
{
    public GameObject boltPrefab = null;
    public float PiercingDMG = 5.0f;
    public float RAG = 4.0f;
    [SerializeField]
    private float piercingDecline = 0.1f;
    [SerializeField]
    private float minnDecline = 0.4f;
    [SerializeField]
    private GameObject cmdCirclePrefab = null;

    private float piercingMult = 1.0f;
    private GameObject cmdCircle = null;
    protected override void StartWaitEffect()
    {
        EndWaitEffect();
        base.StartWaitEffect();
    }

    protected override void InstantEffect()
    {
        if (NPCinfo.target)
        {
            GameObject newProjectile = Instantiate(boltPrefab, transform.position, Quaternion.identity, transform);
            BallisticProjectile ballistic = newProjectile.GetComponent<BallisticProjectile>();
            ballistic.targetPos = transform.position + RAG * (NPCinfo.target.transform.position - transform.position).normalized;
            newProjectile.GetComponent<AOEBase>().OnEnter = PiercingDMGDelegate;
            piercingMult = 1.0f;
        }
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

    private void PiercingDMGDelegate(Collider2D collision)
    {
        if (GameManager.CheckHostile(NPCinfo.tag, collision.tag))
        {
            NPCBase target = collision.GetComponent<NPCBase>();
            NPCinfo.DealDmg2Target(piercingMult * PiercingDMG, target, DMGType.None);
            piercingMult -= piercingDecline;
            piercingMult = Mathf.Clamp(piercingMult, minnDecline, 1.0f);
        }
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
