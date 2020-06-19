using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int money = 1000;
    public GameObject[] Tower = null;
    public int[] TowerCost = null;
    public GameObject BuildPanel = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        //GameObject[] a = GameObject.FindGameObjectsWithTag("Default");

    }
}
