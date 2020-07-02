using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StormAttack : AbilityBase
{
    public GameObject arrowPrefab = null;
    public float DMG = 2.0f;
    public int stormAttackCount = 5;
    public float RAG = 4.0f;
    [SerializeField]
    private GameObject cmdCirclePrefab = null;

    private int cnt = 0;
    private GameObject cmdCircle = null;
    protected override void StartWaitEffect()
    {
        EndWaitEffect();
        base.StartWaitEffect();
    }

    protected override void InstantEffect()
    {
        base.InstantEffect();
        cnt = stormAttackCount;
    }

    protected override void ChannelingEffect()
    {
        base.ChannelingEffect();
        channeling -= Time.deltaTime;
        if (cnt > 0)
        {
            if (channeling <= castAnim / stormAttackCount * cnt)
            {
                cnt--;
                GameObject newArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
                HomingArrow homingArrow = newArrow.GetComponent<HomingArrow>();
                homingArrow.destination = NPCinfo.target.transform;
                homingArrow.grounded += delegate
                {
                    if (NPCinfo.target) NPCinfo.target.DealDmg(DMG);
                };
            }
        }
        else Interrupt();
    }
    public override bool CheckTarget()
    {
        return (NPCinfo.target && Vector3.Distance(transform.position, NPCinfo.target.transform.position) < RAG);
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
