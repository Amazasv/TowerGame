using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPanel : MonoBehaviour
{
    public static InfoPanel Instance = null;
    public NPCInfo currentObject = null;
    public Text NPCTag = null;
    public Text HealthValue = null;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    private void Update()
    {
        if (currentObject)
        {
            NPCTag.text = currentObject.NPCName;
            HealthValue.text = currentObject.health.ToString();
        }
    }


}
