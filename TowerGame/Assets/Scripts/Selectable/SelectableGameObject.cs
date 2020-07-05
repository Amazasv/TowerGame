using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectableGameObject : MonoBehaviour, IPointerClickHandler
{
    public VoidDelegate UnSelectEvent = null;
    public VoidDelegate OnClickEvent = null;
    public VoidDelegate OnClickTrigger = null;

    private static SelectableGameObject m_currentSelected = null;
    public static SelectableGameObject CurrentSelected
    {
        get { return m_currentSelected; }
        set
        {
            if (m_currentSelected) m_currentSelected.UnSelectEvent?.Invoke();
            m_currentSelected = value;
            if (m_currentSelected)
            {
                m_currentSelected.OnClickEvent?.Invoke();
                m_currentSelected.OnClickTrigger?.Invoke();
                m_currentSelected.OnClickTrigger = null;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        CurrentSelected = this;
    }
    private void OnDestroy()
    {
        CurrentSelected = null;
    }
}
