using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnUnselectObject : MonoBehaviour
{
    private Button btn = null;
    private void Awake()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { SelectableGameObject.CurrentSelected = null; });
    }
}
