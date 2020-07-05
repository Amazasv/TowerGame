using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AssembleLayout))]
public class CampManager : MonoBehaviour
{
    [SerializeField]
    private int maxSoliderCount = 3;
    [SerializeField]
    private GameObject soldierPrefab = null;
    [SerializeField]
    private float respawnTime = 5.0f;
    
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
        GameObject tmp=Instantiate(soldierPrefab, transform);
        tmp.GetComponent<NPCBase>().OnDead += StartRespawn;
    }
}
