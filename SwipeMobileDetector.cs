using UnityEngine;

public class SwipeMobileDetector : MonoBehaviour
{
    private Vector3 m_FirstFingerPosition;
    private Vector3 m_LastFingerPosition;
    [SerializeField] private float m_DragDistance;

    void Update()
    {
        Swipe();
    }

    private void Swipe()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                m_FirstFingerPosition = touch.position;
                m_LastFingerPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                m_LastFingerPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (Mathf.Abs(m_LastFingerPosition.x - m_FirstFingerPosition.x) > m_DragDistance || Mathf.Abs(m_LastFingerPosition.y - m_FirstFingerPosition.y) > m_DragDistance)
                {
                    if (Mathf.Abs(m_LastFingerPosition.x - m_FirstFingerPosition.x) > Mathf.Abs(m_LastFingerPosition.y - m_FirstFingerPosition.y))
                    {
                        if (m_LastFingerPosition.x > m_FirstFingerPosition.x)
                        {
                            print("Your code on swipe right");
                        }
                        else
                        {
                            print("Your code on swipe left");

                        }
                    }
                    else
                    {
                        if (m_LastFingerPosition.y > m_FirstFingerPosition.y)
                        {
                            print("Your code on swipe up");

                        }
                        else
                        {
                            print("Your code on swipe down");
                        }
                    }
                }
            }
        }
    }
}
