using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Moveable))]
public class ChargeAttack : AbilityBase
{
    public float additonalSpeedMult = 0.4f;
    public static float AARange = 0.4f;
    public float ChargeDmg = 1.0f;
    public GameObject AOEPrefab = null;
    public float RAG = 4.0f;
    [SerializeField]
    private GameObject cmdCirclePrefab = null;

    private Moveable moveable = null;
    private GameObject cmdCircle = null;
    protected override void UpdateREF()
    {
        base.UpdateREF();
        moveable = GetComponent<Moveable>();
    }

    protected override void StartWaitEffect()
    {
        base.StartWaitEffect();
        moveable.speedMult += additonalSpeedMult;
    }

    protected override void UpdateWaitEffect()
    {
        Vector3 dirVector = transform.position - NPCinfo.target.transform.position;
        moveable.targetPos = NPCinfo.target.transform.position;
        if (dirVector.magnitude <= AARange - 0.01f)
        {
            moveable.targetPos = transform.position;
            EndWaitEffect();
        }
    }

    protected override void InstantEffect()
    {
        base.InstantEffect();
        if (AOEPrefab)
        {
            GameObject AOE = Instantiate(AOEPrefab, transform);
            AOE.transform.Rotate(Vector3.forward, Vector2.SignedAngle(Vector3.right, moveable.dirVec));
            AOE.GetComponent<AOEBase>().OnEnter = InstantDMGDelegate;
        }
    }

    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < RAG);
    }
    protected override void EndWaitEffect()
    {
        moveable.speedMult -= additonalSpeedMult;
        if (anim)
        {
            anim.SetFloat("Horizontal", (NPCinfo.target.transform.position - transform.position).x);
            anim.SetFloat("Vertical", (NPCinfo.target.transform.position - transform.position).y);
        }
        base.EndWaitEffect();
    }

    private void InstantDMGDelegate(Collider2D collision)
    {
        if (GameManager.CheckHostile(NPCinfo.tag, collision.tag))
        {
            NPCBase target = collision.GetComponent<NPCBase>();
            NPCinfo.DealDmg2Target(ChargeDmg, target, DMGType.None);
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
