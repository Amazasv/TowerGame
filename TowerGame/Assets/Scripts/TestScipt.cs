using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestScipt : MonoBehaviour
{
    private SpeedStatus speedStatus=null;

    private void Awake()
    {
        speedStatus = GetComponentInParent<SpeedStatus>();
        GetComponent<Button>().onClick.AddListener(PressEvent);
    }

    private void PressEvent()
    {
        //speedStatus.sadf........
    }

}
