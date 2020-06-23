using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInfo : MonoBehaviour
{
    public NPCInfo target = null;
    public List<StatusBase> statusList = new List<StatusBase>();
    public string NPCName = "";
    public float MaxHealth = 10.0f;
    public float m_Health = 10.0f;

    public float health
    {
        get { return m_Health; }
        set
        {
            m_Health = Mathf.Clamp(value, 0, MaxHealth);
        }
    }

    public bool invincible = false;

    public static float contactRAG = 0.3f;

    private void OnEnable()
    {
        health = MaxHealth;
        if (CompareTag("Ally")) NPCList.allies.Add(this);
        if (CompareTag("Enemy")) NPCList.enemys.Add(this);
    }
    private void Update()
    {
        CheckTarget();
        if (health == 0.0f) Destroy(gameObject);
    }
    public void DealDmg(float value)
    {
        health -= value;
    }

    public void UpdateInfoPanel()
    {
        InfoPanel.Instance.NPCTag.text = NPCName;
        InfoPanel.Instance.HealthValue.text = health.ToString();
    }

    private void OnMouseUpAsButton()
    {
        InfoPanel.Instance.gameObject.SetActive(true);
        UpdateInfoPanel();
    }

    private void CheckTarget()
    {
        if (target && target.invincible) target = null;
    }
    private void OnDisable()
    {
        if (CompareTag("Ally")) NPCList.allies.Remove(this);
        if (CompareTag("Enemy")) NPCList.enemys.Remove(this);
    }
}
