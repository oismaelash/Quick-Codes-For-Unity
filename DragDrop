using UnityEngine;

public class DragDrop : MonoBehaviour
{
  private Vector3 m_ScreenPoint;
  private Vector3 m_Offset;

   private void OnMouseDrag()
   {
      Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_ScreenPoint.z);
      Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + m_Offset;
      transform.position = cursorPosition;
   }

    private void OnMouseDown()
    {
        m_ScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        m_Offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, m_ScreenPoint.z));
    }
}
