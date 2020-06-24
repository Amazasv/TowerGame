using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimOVR : MonoBehaviour
{
    [SerializeField]
    private AnimatorOverrideController animOVR = null;
    [SerializeField]
    private AnimationClip animClip = null;
    private void Start()
    {
        Debug.Log(animOVR["00_a_sample"] = animClip);
    }
}
