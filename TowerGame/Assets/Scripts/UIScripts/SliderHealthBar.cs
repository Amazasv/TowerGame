using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class SliderHealthBar : MonoBehaviour
{
    private NPCBase NPCinfo = null;
    private Slider slider = null;
    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        NPCinfo = GetComponentInParent<NPCBase>();
    }

    private void Update()
    {
        if (NPCinfo.Dead) slider.gameObject.SetActive(false);
        else
        {
            slider.value = NPCinfo.health / NPCinfo.MaxHealth;
            slider.gameObject.SetActive(true);
        }
    }
}
