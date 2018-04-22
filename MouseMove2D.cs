using UnityEngine;
using System.Collections;
 
public class MouseMove2D : MonoBehaviour 
{ 
    private Vector3 mousePosition;
    [SerializeField] private float moveSpeed = 0.1f;
    
    // Update is called once per frame
    private void Update () 
    {
        if (Input.GetMouseButton(0)) // Button left mouse 
        {
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector3.Lerp(transform.position, mousePosition, moveSpeed);
        }
    }
}
