using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void VoidDelegate();


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public SelectableGameObject BG = null;
    public GetClickPosObject WalkableArea = null;
    public GetClickPosObject NonWalkableArea = null;
    public Transform UICanvas = null;

    [SerializeField]
    private SelectableGameObject m_currentSelected = null;
    public SelectableGameObject CurrentSelected
    {
        get { return m_currentSelected; }
        set
        {
            if (m_currentSelected)
            {
                m_currentSelected.UnSelectEvent?.Invoke();
            }
            m_currentSelected = value;
            if (m_currentSelected)
            {
                m_currentSelected.OnClickEvent?.Invoke();
                m_currentSelected.OnClickTrigger?.Invoke();
                m_currentSelected.OnClickTrigger = null;
            }
        }
    }

    public int money = 1000;
    [SerializeField]
    private int m_hearts = 10;
    public int hearts
    {
        get { return m_hearts; }
        set
        {
            m_hearts = value;
            if (value < 0) GameOver();
        }
    }
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
    public void GameOver()
    {
        Time.timeScale = 0.0f;
    }

    public static bool CheckHostile(string tag1,string tag2)
    {
        bool res = false;
        if (tag1.Equals("Ally") && tag2.Equals("Enemy")) res = true;
        if (tag1.Equals("Enemy") && tag2.Equals("Ally")) res = true;
        return res;
    }
}
