using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[RequireComponent(typeof(Canvas))]
public class AssignMainCamera : MonoBehaviour
{
    private void Awake()
    {
        GameObject cam = GameObject.FindWithTag("MainCamera");
        GetComponent<Canvas>().worldCamera = cam.GetComponent<Camera>();
    }
}
