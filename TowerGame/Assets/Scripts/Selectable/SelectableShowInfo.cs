using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SelectableGameObject))]
public class SelectableShowInfo : MonoBehaviour
{
    [SerializeField]
    private GameObject InfoPrefab = null;

    private SelectableGameObject selectableGameObject = null;
    private GameObject info = null;
    private void Awake()
    {
        selectableGameObject = GetComponent<SelectableGameObject>();
        selectableGameObject.OnClickEvent += InstantiateNew;
        selectableGameObject.UnSelectEvent += DestroyLast;
    }

    private void InstantiateNew()
    {
        DestroyLast();
        if (InfoPrefab) info = Instantiate(InfoPrefab, GameManager.Instance.UICanvas);
        if (info)
        {
            SliderHealthBar tmp = info.GetComponentInChildren<SliderHealthBar>();
            if (tmp) tmp.NPCinfo = GetComponent<NPCBase>();
        }
    }

    private void DestroyLast()
    {
        if (info) Destroy(info);
    }
}
