﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SelectableGameObject))]
public class TowerBase : MonoBehaviour
{
    public GameObject IntroPrefab = null;
    public GameObject panelPrefab = null;
    public int cost = 20;
    public int refund = 0;

    private void Awake()
    {
        GetComponent<SelectableGameObject>().OnClickEvent += ShowPanel;
        GetComponent<SelectableGameObject>().UnSelectEvent += ClosePanel;
    }
    private void ShowPanel()
    {
        if (panelPrefab) Instantiate(panelPrefab, transform);
    }

    private void ClosePanel()
    {
        PanelController panelController = GetComponentInChildren<PanelController>();
        if (panelController) panelController.ClosePanel();
    }
}
