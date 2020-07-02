using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Text))]
public class TextDisplayHeart : MonoBehaviour
{
    private Text text = null;
    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void Update()
    {
        text.text = GameManager.Instance.hearts.ToString();
    }
}
