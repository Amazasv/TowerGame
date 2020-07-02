using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScipt : MonoBehaviour
{
    private GameObject newObject = null;

    [SerializeField]
    private GameObject prefab = null;
    public void Ins()
    {
        if (newObject) Destroy(newObject);
        newObject = Instantiate(prefab, transform);
    }
}
