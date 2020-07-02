using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstructor : MonoBehaviour
{
    [SerializeField]
    private Transform defaultPoint = null;

    private TowerBase tower = null;

    private void Awake()
    {
        tower = GetComponentInChildren<TowerBase>();
    }
    public void Build(GameObject towerPrefab)
    {
        //if (PanelController.Instance) PanelController.Instance.ClosePanel();//mark
        if (tower) Destroy(tower.gameObject);
        if (towerPrefab)
        {
            tower = Instantiate(towerPrefab, transform).GetComponent<TowerBase>();
            AssembleLayout assemble = tower.GetComponentInChildren<AssembleLayout>();
            if (assemble) assemble.SetAssemblyPoint(defaultPoint.position);
            GameManager.Instance.money -= tower.cost;
        }
    }
}
