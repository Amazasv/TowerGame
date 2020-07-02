using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpionAttack : AbilityBase
{
    public GameObject boltPrefab = null;
    public GameObject AOEPrefab = null;
    public float PiercingDMG = 5.0f;
    public float ExplodeDMG = 5.0f;
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
        if (NPCinfo.target)
        {
            GameObject newProjectile = Instantiate(boltPrefab, transform.position, Quaternion.identity, transform);

            BallisticProjectile ballistic = newProjectile.GetComponent<BallisticProjectile>();
            ballistic.targetPos = transform.position + RAG * (NPCinfo.target.transform.position - transform.position).normalized;
            ballistic.grounded += delegate
            {
                GameObject AOE = Instantiate(AOEPrefab, ballistic.transform.position, Quaternion.identity, ballistic.transform);
                AOE.GetComponent<AOEInstantDmg>().collisionEvent = ExplodeDMGDelegate;
            };

            newProjectile.GetComponent<AOEInstantDmg>().collisionEvent = PiercingDMGDelegate;
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
        NPCBase target = collision.GetComponent<NPCBase>();
        if (target) target.DealDmg(PiercingDMG, DMGType.None);
    }
    private void ExplodeDMGDelegate(Collider2D collision)
    {
        NPCBase target = collision.GetComponent<NPCBase>();
        if (target) target.DealDmg(ExplodeDMG, DMGType.None);
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
