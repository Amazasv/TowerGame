using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnCommand : MonoBehaviour
{
    private CommandAbility commandAbility = null;
    private PanelController panelController = null;
    private Button btn = null;
    private void Awake()
    {
        commandAbility = GetComponentInParent<CommandAbility>();
        panelController = GetComponentInParent<PanelController>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(Command);
        btn.onClick.AddListener(ClosePanel);
    }
    private void Command()
    {
        commandAbility.Use();
    }

    private void ClosePanel()
    {
        panelController.ClosePanel();
    }
}
