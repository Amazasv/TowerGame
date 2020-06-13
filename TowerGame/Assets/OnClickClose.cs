using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickClose : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        if (PanelController.Instance) PanelController.Instance.ClosePanel();
    }
}
