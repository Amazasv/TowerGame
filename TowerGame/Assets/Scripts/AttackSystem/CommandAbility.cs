﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandAbility : AbilityBase
{
    public float RAG = 4.0f;
    [SerializeField]
    private GameObject cmdCirclePrefab = null;

    private GameObject cmdCircle = null;
    private AssembleLayout assembleLayout = null;
    private GetClickPosObject walkableArea = null;
    private GetClickPosObject nonWalkableArea = null;
    protected override void UpdateREF()
    {
        base.UpdateREF();
        assembleLayout = GetComponentInChildren<AssembleLayout>();
        if (assembleLayout == null) assembleLayout = GetComponentInParent<AssembleLayout>();
    }

    private void Start()
    {
        walkableArea = GameManager.Instance.WalkableArea;
        nonWalkableArea = GameManager.Instance.NonWalkableArea;
    }

    protected override void StartWaitEffect()
    {
        walkableArea.gameObject.layer = LayerMask.NameToLayer("Default");
        nonWalkableArea.gameObject.layer = LayerMask.NameToLayer("Default");
        walkableArea.OnClickEvent += CheckPoint;
        nonWalkableArea.OnClickEvent += CantSetPoint;
    }
    private void CantSetPoint(Vector2 input)
    {
        Debug.Log("Not Walkable");
    }

    private void CheckPoint(Vector2 input)
    {
        if (Vector2.Distance(input, transform.position) < RAG)
        {
            walkableArea.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            nonWalkableArea.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            walkableArea.OnClickEvent -= CheckPoint;
            nonWalkableArea.OnClickEvent -= CantSetPoint;
            GameManager.Instance.CurrentSelected = null;
            assembleLayout.SetAssemblyPoint(input);

            Interrupt();
        }
        else
        {
            Debug.Log("Out of Range");
        }
    }
    public override bool CheckTarget()
    {
        return true;
    }
    public override void ShowIndicator()
    {
        if (cmdCirclePrefab)
        {
            cmdCircle = Instantiate(cmdCirclePrefab, transform);
            cmdCircle.transform.localScale = RAG * 2 * Vector2.one;
        }
    }
    public override void HideIndicator()
    {
        if (cmdCircle) Destroy(cmdCircle);
    }
}
