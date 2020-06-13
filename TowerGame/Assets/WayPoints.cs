using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteAlways]
public class WayPoints : MonoBehaviour
{
    public Vector3[] pointsPos = null;
    [SerializeField]
    private Color GizmosLineColor = Color.red;

    private void Awake()
    {
        UpdatePointsPos();
    }

    private void UpdatePointsPos()
    {
        pointsPos = new Vector3[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            pointsPos[i] = transform.GetChild(i).position;
        }
    }

    private void Update()
    {
#if UNITY_EDITOR
        UpdatePointsPos();
#endif
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = GizmosLineColor;
        for (int i = 1; i < pointsPos.Length; i++)
        {
            Gizmos.DrawLine(pointsPos[i - 1], pointsPos[i]);
        }
    }

}
