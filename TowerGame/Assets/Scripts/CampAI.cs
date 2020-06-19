using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampAI : MonoBehaviour
{
    [SerializeField]
    private float CommandRadius = 3.0f;
    [SerializeField]
    private int maxSoliderCount = 3;
    [SerializeField]
    private float respawnTime = 5.0f;
    [SerializeField]
    private GameObject soldierPrefab = null;
    [SerializeField]
    private Transform soldiersContainer = null;

    public Transform assemblyPoint = null;

    private bool waitClick = false;
    private float respawnCD = 0.0f;
    private void Awake()
    {
        CreateSolider(maxSoliderCount);
    }

    private void Update()
    {
        TryRespawn();
        if (waitClick && Input.GetMouseButtonDown(0))
        {
            waitClick = false;
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(mousePos, transform.position) < CommandRadius)
            {
                assemblyPoint.position = mousePos;
            }

        }
    }

    private void CreateSolider(int cnt = 1)
    {
        for (int i = 0; i < cnt; i++)
        {
            Instantiate(soldierPrefab, soldiersContainer);
        }
    }

    private void SetAssemblyPoint()//called by SendMessageUpwards()
    {
        waitClick = true;
    }

    private void TryRespawn()
    {
        if (respawnCD <= 0.0f)
        {
            if (GetComponentsInChildren<NPCInfo>().Length < maxSoliderCount)
            {
                respawnCD = respawnTime;
                CreateSolider();
            }
        }
        else respawnCD -= Time.deltaTime;
    }


}
