using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(NPCBase))]
[RequireComponent(typeof(Moveable))]
public class MouseMove : MonoBehaviour
{
    private CommandAbility commandAbility = null;

    private void Awake()
    {
        commandAbility = GetComponentInParent<CommandAbility>();
        GetComponent<SelectableGameObject>().OnClickEvent += delegate { commandAbility.Use(); };
    }
}
