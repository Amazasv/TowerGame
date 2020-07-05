using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelimitStatus : MonoBehaviour
{
    public float duration = 3.0f;
    private void Update()
    {
        if (duration > 0.0f) { duration -= Time.deltaTime; }
        else Destroy(this);
    }
}
