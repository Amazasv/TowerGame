using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NPCHealth : MonoBehaviour
{
    public float MaxHealth = 10.0f;
    public float health = 10.0f;
    [SerializeField]
    private Slider HealthBar = null;

    private void Awake()
    {
        health = MaxHealth;
    }
    private void Update()
    {
        UpdateVisuals();
        if (health <= 0.0f) Destroy(gameObject);
    }
    public void DealDmg(float value)
    {
        health -= value;
    }
    private void UpdateVisuals()
    {
        if (HealthBar) HealthBar.value = health / MaxHealth;
    }
}
