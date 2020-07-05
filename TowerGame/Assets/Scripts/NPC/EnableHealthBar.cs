using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NPCBase))]
public class EnableHealthBar : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBarPrefab = null;

    private void Awake()
    {
        if (healthBarPrefab)
        {
            GameObject tmp=Instantiate(healthBarPrefab, transform);
            tmp.GetComponent<SliderHealthBar>().NPCinfo = GetComponent<NPCBase>();
        }
    }
}
