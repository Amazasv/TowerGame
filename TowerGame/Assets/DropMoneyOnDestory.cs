using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropMoneyOnDestory : MonoBehaviour
{
    [SerializeField]
    private int value = 0;
    private void OnDestroy()
    {
        GameManager.Instance.money += value;
    }
}
