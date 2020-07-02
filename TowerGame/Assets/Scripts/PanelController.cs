using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    private Animator anim = null;
    private BtnBuildTower[] btns = null;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        btns = GetComponentsInChildren<BtnBuildTower>();
    }

    public void CancelPreview()
    {
        foreach (BtnBuildTower btn in btns) btn.Cancel();
    }

    public void ClosePanel()
    {
        if (anim) anim.SetTrigger("Destroy");
        else Destroy(gameObject);
    }
}
