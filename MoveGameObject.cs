using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGameObject : MonoBehaviour
{
    public enum Direction
    {
        Up, Down, Left, Right
    };

    [SerializeField] private Direction m_DirectionMove;
    [SerializeField] private float m_VelocityMoviment;

    private void Update()
    {
        switch (m_DirectionMove)
        {
            case Direction.Up:
                transform.Translate(Vector3.up * Time.deltaTime * m_VelocityMoviment);
                break;
            case Direction.Down:
                transform.Translate(Vector3.down * Time.deltaTime * m_VelocityMoviment);
                break;
            case Direction.Left:
                transform.Translate(Vector3.left * Time.deltaTime * m_VelocityMoviment);
                break;
            case Direction.Right:
                transform.Translate(Vector3.right * Time.deltaTime * m_VelocityMoviment);
                break;
        }
    }
}
