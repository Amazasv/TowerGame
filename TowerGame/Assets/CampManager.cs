using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampManager : MonoBehaviour
{
    private AssembleLayout assembleLayout = null;
    [SerializeField]
    private int maxSoliderCount = 3;
    [SerializeField]
    private GameObject soldierPrefab = null;
    [SerializeField]
    private float respawnTime = 5.0f;
    private void Awake()
    {
        assembleLayout = GetComponentInChildren<AssembleLayout>();
    }
    private void Start()
    {
        for (int i = 0; i < maxSoliderCount; i++)
        {
            CreateSolider();
        }
    }
    public void StartRespawn()
    {
        Invoke("CreateSolider", respawnTime);
    }
    private void CreateSolider()
    {
        Instantiate(soldierPrefab, assembleLayout.transform);
    }
}
