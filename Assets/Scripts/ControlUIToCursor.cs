using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControlUIToCursor : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    public bool isOverUI;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        isOverUI = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isOverUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOverUI = false;
    }
}
