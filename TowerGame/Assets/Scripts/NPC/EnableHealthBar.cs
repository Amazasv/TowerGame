using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableHealthBar : MonoBehaviour
{
    [SerializeField]
    private GameObject healthBarPrefab = null;

    private void Awake()
    {
        if (healthBarPrefab) Instantiate(healthBarPrefab, transform);
    }
}
