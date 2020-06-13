using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnClearPanel : MonoBehaviour
{
    private Button btn = null;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(ray);
            if (PanelController.Instance) PanelController.Instance.ClosePanel(); 
        }
        );
    }
}
