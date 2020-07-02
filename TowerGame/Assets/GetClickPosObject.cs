using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public delegate void Vec2Delegate(Vector2 input);
public class GetClickPosObject : MonoBehaviour,IPointerClickHandler
{
    public Vec2Delegate OnClickEvent;
    public Vec2Delegate OnClickTrigger;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent?.Invoke(eventData.pointerPressRaycast.worldPosition);
        OnClickTrigger?.Invoke(eventData.pointerPressRaycast.worldPosition);
        OnClickTrigger = null;
    }
}
