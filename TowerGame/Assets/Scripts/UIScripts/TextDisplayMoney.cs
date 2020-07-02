using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class TextDisplayMoney : MonoBehaviour
{
    private Text m_Text = null;
    private void Awake()
    {
        m_Text = GetComponent<Text>();
    }

    private void Update()
    {
        m_Text.text = GameManager.Instance.money.ToString();
    }
}
