using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampAI : MonoBehaviour
{
    private static float CommandRadius = 3.0f;


    [SerializeField]
    private int maxSoliderCount = 3;

    [SerializeField]
    private GameObject soldierPrefab = null;
    [SerializeField]
    private Transform soldiersContainer = null;
    
    public Transform assemblyPoint = null;

    private bool waitClick = false;
    private void Awake()
    {
        if (soldierPrefab && soldiersContainer)
        {
            CreateSolider(maxSoliderCount);
        }
    }

    private void CreateSolider(int cnt = 1)
    {
        for (int i = 0; i < cnt; i++)
        {
            GameObject soldier = Instantiate(soldierPrefab, soldiersContainer);
            if (soldier) soldier.GetComponent<Assemble>().origin = assemblyPoint;
        }
    }


    private void Update()
    {
        if (waitClick && Input.GetMouseButtonDown(0))
        {
            waitClick = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, transform.position) < CommandRadius)
            {
                assemblyPoint.position = mousePos;
            }

        }
    }
    private void SetAssemblyPoint()
    {
        waitClick = true;
    }


}
