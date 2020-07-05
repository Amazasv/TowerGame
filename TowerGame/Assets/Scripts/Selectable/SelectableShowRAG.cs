using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SelectableGameObject))]
public class SelectableShowRAG : MonoBehaviour
{
    private AbilityBase[] abilityBases = null;
    private SelectableGameObject selectableGameObject = null;
    private void Awake()
    {
        abilityBases = GetComponents<AbilityBase>();
        selectableGameObject = GetComponent<SelectableGameObject>();
        selectableGameObject.OnClickEvent += ShowAbilityRAG;
        selectableGameObject.UnSelectEvent += HideAbilityRAG;
    }
    private void ShowAbilityRAG()
    {
        foreach (AbilityBase abilityBase in abilityBases)
            abilityBase.ShowIndicator();
    }
    private void HideAbilityRAG()
    {
        foreach (AbilityBase abilityBase in abilityBases)
            abilityBase.HideIndicator();
    }
}
