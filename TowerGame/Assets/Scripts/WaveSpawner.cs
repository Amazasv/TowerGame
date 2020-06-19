using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public static WaveSpawner Instance { get; private set; }
    [SerializeField]
    private GameObject enemyPrefab = null;
    [SerializeField]
    private Transform[] spawnPoints = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SpawnAnEnemy()
    {
        int index = Random.Range(0, spawnPoints.Length);
        GameObject enemy = Instantiate(enemyPrefab, spawnPoints[index].position, Quaternion.identity, transform);
        enemy.GetComponent<MoveAlongPath>().wayPoints = spawnPoints[index].GetComponentInParent<WayPoints>();
    }
}
