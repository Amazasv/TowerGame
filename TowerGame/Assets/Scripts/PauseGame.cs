using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseGame : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(delegate { Time.timeScale = 0; });
    }
}
