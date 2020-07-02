using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableGameObject : MonoBehaviour, IPointerClickHandler
{
    public VoidDelegate UnSelectEvent = null;
    public VoidDelegate OnClickEvent = null;
    public VoidDelegate OnClickTrigger = null;
    public GameObject InfoPrefab = null;

    private GameObject info = null;
    public void OnPointerClick(PointerEventData eventData)
    {
        GameManager.Instance.CurrentSelected = this;
    }
    private void Awake()
    {
        OnClickEvent += InstantiateNew;
        UnSelectEvent += DestroyLast;
    }

    private void InstantiateNew()
    {
        if (InfoPrefab) info = Instantiate(InfoPrefab, GameManager.Instance.UICanvas);
    }

    private void DestroyLast()
    {
        if (info) Destroy(info);
    }

    private void OnDestroy()
    {
        if (GameManager.Instance.CurrentSelected == this) GameManager.Instance.CurrentSelected = null;
    }
}
