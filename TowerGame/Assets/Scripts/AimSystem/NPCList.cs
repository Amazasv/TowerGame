using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class NPCList
{
    public static List<NPCInfo> enemys = new List<NPCInfo>();
    public static List<NPCInfo> allies = new List<NPCInfo>();


    public static NPCInfo NearestAllEnemy(Transform origin)
    {
        NPCInfo target = null;
        foreach (NPCInfo tmp in enemys)
        {
            if (tmp.invincible) continue;
            if (target == null || GetDistance(tmp.transform, origin) < GetDistance(target.transform, origin))
                target = tmp;
        }
        return target;
    }
    public static NPCInfo NearestFreeEnemy(Transform origin)
    {
        NPCInfo target = null;
        foreach (NPCInfo tmp in enemys)
        {
            if (tmp.invincible) continue;
            if (tmp.target == null)
            {
                if (target == null || GetDistance(tmp.transform, origin) < GetDistance(target.transform, origin))
                    target = tmp;
            }
        }
        return target;
    }
    public static NPCInfo NearestAllAlly(Transform origin)
    {
        NPCInfo target = null;
        foreach (NPCInfo tmp in allies)
        {
            if (tmp.invincible) continue;
            if (target == null || GetDistance(tmp.transform, origin) < GetDistance(target.transform, origin))
                target = tmp;
        }
        return target;
    }
    public static NPCInfo NearestFreeAlly(Transform origin)
    {
        NPCInfo target = null;
        foreach (NPCInfo tmp in allies)
        {
            if (tmp.invincible) continue;
            if (tmp.target == null)
            {
                if (target == null || GetDistance(tmp.transform, origin) < GetDistance(target.transform, origin))
                    target = tmp;
            }
        }
        return target;
    }

    private static float GetDistance(Transform a, Transform b)
    {
        return Vector2.Distance(a.transform.position, b.transform.position);
    }
}
