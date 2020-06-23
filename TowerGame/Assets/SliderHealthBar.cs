using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class SliderHealthBar : MonoBehaviour
{
    private NPCInfo NPCinfo = null;
    private Slider slider = null;
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        NPCinfo = GetComponentInParent<NPCInfo>();
    }

    private void Update()
    {
        slider.value = NPCinfo.health / NPCinfo.MaxHealth;
    }
}
