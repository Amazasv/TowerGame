using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnCheckMoney : MonoBehaviour
{
    [SerializeField]
    private int cost = 0;

    private Button btn = null;
    private void Awake()
    {
        btn = GetComponent<Button>();
    }
    private void Update()
    {
        if (cost == 0 || GameManager.Instance.money >= cost) btn.interactable = true;
        else btn.interactable = false;
    }
}
