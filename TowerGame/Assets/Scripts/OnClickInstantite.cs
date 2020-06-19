using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickInstantite : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab = null;
    [SerializeField]
    private Transform parent = null;
    private void OnMouseUpAsButton()
    {
        if (prefab)
            if (parent) Instantiate(prefab, parent);
            else Instantiate(prefab, transform);
    }
}
