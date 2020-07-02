using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class NPCList
{
    public static List<NPCBase> enemys = new List<NPCBase>();
    public static List<NPCBase> allies = new List<NPCBase>();


    public static NPCBase NearestAllEnemy(Transform origin)
    {
        NPCBase target = null;
        foreach (NPCBase tmp in enemys)
        {
            if (tmp.invincible) continue;
            if (target == null || GetDistance(tmp.transform, origin) < GetDistance(target.transform, origin))
                target = tmp;
        }
        return target;
    }
    public static NPCBase NearestFreeEnemy(Transform origin)
    {
        NPCBase target = null;
        foreach (NPCBase tmp in enemys)
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
    public static NPCBase NearestAllAlly(Transform origin)
    {
        NPCBase target = null;
        foreach (NPCBase tmp in allies)
        {
            if (tmp.invincible) continue;
            if (target == null || GetDistance(tmp.transform, origin) < GetDistance(target.transform, origin))
                target = tmp;
        }
        return target;
    }
    public static NPCBase NearestFreeAlly(Transform origin)
    {
        NPCBase target = null;
        foreach (NPCBase tmp in allies)
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
