using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DragCameraMobile : MonoBehaviour
{
    [SerializeField] private float m_Velocity;

    if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
    {
        var touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        var newX = -touchDeltaPosition.x * m_Velocity * Time.deltaTime;
        var newY =-touchDeltaPosition.y * m_Velocity * Time.deltaTime;

        transform.Translate(newX, newY, 0);
    }
}
