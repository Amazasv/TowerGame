using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPanel : MonoBehaviour
{
    public static InfoPanel Instance = null;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }


    public Text NPCTag = null;
    public Text HealthValue = null;
}
