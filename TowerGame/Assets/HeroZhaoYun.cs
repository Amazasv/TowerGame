using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroZhaoYun : MonoBehaviour
{
    [SerializeField]
    private float detectRAG = 3.0f;
    [SerializeField]
    private int maxBoostCnt = 5;
    [SerializeField]
    private float attackBoostPerLevel = 0.2f;
    [SerializeField]
    private float movementSpeedBoostPerLevel = 0.2f;
    [SerializeField]
    private float detectCD = 1.0f;
    [SerializeField]
    private Color BoostColor = Color.red;

    private NPCBase NPCbase = null;
    private Moveable moveable = null;
    private SpriteRenderer spriteRenderer = null;
    private float attackBoost = 0.0f;
    private float moveBoost = 0.0f;

    private void Awake()
    {
        NPCbase = GetComponent<NPCBase>();
        moveable = GetComponent<Moveable>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    private void Start()
    {
        InvokeRepeating("UpdateState", 0.0f, detectCD);
    }

    private void UpdateState()
    {
        NPCbase.globalAttackMult -= attackBoost;
        moveable.speedMult -= moveBoost;
        int cnt = 0;
        foreach (NPCBase tmp in NPCList.allies)
        {
            if (!tmp.invincible && tmp != NPCbase && Vector2.Distance(tmp.transform.position, transform.position) <= detectRAG)
            {
                cnt++;
            }
        }
        if (cnt < maxBoostCnt)
        {
            attackBoost = attackBoostPerLevel * (maxBoostCnt - cnt);
            moveBoost = movementSpeedBoostPerLevel * (maxBoostCnt - cnt);
        }
        NPCbase.globalAttackMult += attackBoost;
        moveable.speedMult += moveBoost;
        UpdateVisuals(cnt);
    }

    private void UpdateVisuals(int cnt)
    {
        spriteRenderer.color = Color.Lerp(Color.white, BoostColor, 1.0f - (1.0f * cnt) / (1.0f * maxBoostCnt));
    }

}
