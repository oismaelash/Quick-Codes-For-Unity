using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VerificationIfTouchUI : MonoBehaviour
{
    private void Update()
    {
        if(IsPointerOverUIObject())
        {
            print("Touch UI on Update");
            return;
        }
    }

    public void OnMouseDown()
    {
        if (IsPointerOverUIObject())
        {
            print("Touch UI on MouseDown");
            return;
        }
    }

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
