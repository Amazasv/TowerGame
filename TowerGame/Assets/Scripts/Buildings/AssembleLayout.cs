using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleLayout : MonoBehaviour
{
    [SerializeField]
    private Transform assemblyPoint = null;
    [SerializeField]
    private float offsetRadius = 0.2f;

    public List<Assemble> NPCList = new List<Assemble>();
    public VoidDelegate OnRelocate = null;
    public Vector3 GetTargetPoint(Assemble input)
    {
        int length = NPCList.Count;
        int index = NPCList.IndexOf(input);
        if (length == 1) return assemblyPoint.position;
        else return assemblyPoint.position + offsetRadius * new Vector3(Mathf.Cos(2 * Mathf.PI / length * index), Mathf.Sin(2 * Mathf.PI / length * index));
    }

    public void SetAssemblyPoint(Vector2 input)
    {
        assemblyPoint.position = input;
        OnRelocate?.Invoke();
    }

    private void Start()
    {
        OnRelocate?.Invoke();
    }

    public Transform GetAssemblyPoint()//mark不满意
    {
        return assemblyPoint.transform;
    }
}
