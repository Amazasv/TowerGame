using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class BtnCommand : MonoBehaviour
{
    private CommandAbility commandAbility = null;
    private Button btn = null;
    private void Awake()
    {
        commandAbility = GetComponentInParent<CommandAbility>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { commandAbility.Use(); });
    }
}
