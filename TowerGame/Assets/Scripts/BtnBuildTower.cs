using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class BtnBuildTower : MonoBehaviour
{
    [SerializeField]
    private int TowerIndex = 0;
    
    private BuildingConstructor script = null;
    private void Awake()
    {
        script = GetComponentInParent<BuildingConstructor>();
        if (script) GetComponent<Button>().onClick.AddListener(delegate { script.Build(TowerIndex); });
    }
}
