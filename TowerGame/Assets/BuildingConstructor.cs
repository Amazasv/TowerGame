using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingConstructor : MonoBehaviour
{
    [SerializeField]
    private Transform defaultPoint = null;

    public GameObject tower = null;
    public void Build(int index)
    {
        if (PanelController.Instance) PanelController.Instance.ClosePanel();
        if (tower) Destroy(tower);
        tower = Instantiate(GameManager.Instance.Tower[index], transform);
        CampAI assemble = tower.GetComponent<CampAI>();
        if (assemble) assemble.assemblyPoint.position = defaultPoint.position;

        GameManager.Instance.money -= GameManager.Instance.TowerCost[index];
    }
}
