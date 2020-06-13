using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PanelController : MonoBehaviour
{
    public static PanelController Instance { get; private set; }


    private Animator anim = null;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        if (Instance) Instance.ClosePanel();
        Instance = this;
    }

    public void ClosePanel()
    {
        anim.SetTrigger("Destory");
    }
}
