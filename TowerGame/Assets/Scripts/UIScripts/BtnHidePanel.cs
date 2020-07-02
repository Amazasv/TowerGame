using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Button))]
public class BtnHidePanel : MonoBehaviour
{
    private PanelController panelController = null;
    private void Awake()
    {
        panelController = GetComponentInParent<PanelController>();
        GetComponent<Button>().onClick.AddListener(panelController.ClosePanel);
    }
}
