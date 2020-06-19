using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleLayout : MonoBehaviour
{
    public Transform assemblyPoint = null;
    public float radius = 0.2f;

    public List<Assemble> assembleList = new List<Assemble>();

    public Vector3 GetTargetPoint(Assemble input)
    {
        int length = assembleList.Count;
        int index = assembleList.IndexOf(input);
        if (length == 1) return assemblyPoint.position;
        else return assemblyPoint.position + radius * new Vector3(Mathf.Cos(2 * Mathf.PI / length * index), Mathf.Sin(2 * Mathf.PI / length * index));
    }
}
