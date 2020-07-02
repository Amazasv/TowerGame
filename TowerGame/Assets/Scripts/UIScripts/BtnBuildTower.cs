using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class BtnBuildTower : MonoBehaviour
{
    public GameObject towerPrefab = null;
    [SerializeField]
    private GameObject checkMark = null;
    [SerializeField]
    private GameObject icon = null;

    private Vector2 IntroOffset = new Vector2(300.0f, 0.0f);


    private GameObject IntroObject = null;
    private Button btn = null;
    private PanelController panelController = null;
    private BuildingConstructor buildConstructor = null;
    private void Awake()
    {
        buildConstructor = GetComponentInParent<BuildingConstructor>();
        panelController = GetComponentInParent<PanelController>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Preview);
        checkMark.SetActive(false);
    }

    private void Preview()
    {
        panelController.CancelPreview();
        IntroObject = Instantiate(towerPrefab.GetComponent<TowerBase>().IntroPrefab, transform.parent);
        IntroObject.GetComponent<RectTransform>().anchoredPosition = transform.position.x > 0.0f ? -IntroOffset : IntroOffset;
        icon.SetActive(false);
        checkMark.SetActive(true);
        btn.onClick.RemoveListener(Preview);
        btn.onClick.AddListener(Confirm);
    }

    private void Confirm()
    {
        if (buildConstructor) buildConstructor.Build(towerPrefab);
        Cancel();
    }

    public void Cancel()
    {
        if (IntroObject) Destroy(IntroObject);
        icon.SetActive(true);
        checkMark.SetActive(false);
        btn.onClick.RemoveListener(Confirm);
        btn.onClick.AddListener(Preview);
    }

    private void Update()
    {
        btn.interactable = GameManager.Instance.money >= towerPrefab.GetComponent<TowerBase>().cost;
    }
}
