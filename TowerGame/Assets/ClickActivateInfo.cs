using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickActivateInfo : MonoBehaviour
{
    private void OnMouseUpAsButton()
    {
        InfoPanel.Instance.gameObject.SetActive(true);
    }
}
