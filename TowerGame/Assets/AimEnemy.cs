using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AimEnemy : MonoBehaviour
{
    public EnemyAI AimTarget(string tag, float searchRadius)
    {
        EnemyAI target = null;

        foreach (EnemyAI tmp in WaveSpawner.Instance.GetComponentsInChildren<EnemyAI>())
        {
            if (tag == "All" || tmp.tag == tag)
            {
                if (target == null || GetDistance(tmp.transform, transform) < GetDistance(target.transform, transform))
                    target = tmp;
            }

        }
        if (target && GetDistance(target.transform, transform) > searchRadius) target = null;
        return target;
    }

    private float GetDistance(Transform a, Transform b)
    {
        return Vector3.Distance(a.transform.position, b.transform.position);
    }
}
