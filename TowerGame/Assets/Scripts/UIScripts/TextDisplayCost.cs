using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextDisplayCost : MonoBehaviour
{
    [SerializeField]
    private string prefix = "";
    [SerializeField]
    private string suffix = "";

    private Text text = null;
    private BtnBuildTower btnBuildTower = null;
    private void Awake()
    {
        text = GetComponentInChildren<Text>();
        btnBuildTower = GetComponentInParent<BtnBuildTower>();
    }
    private void Update()
    {
        text.text = prefix + btnBuildTower.towerPrefab.GetComponent<TowerBase>().cost.ToString() + suffix;
    }
}
