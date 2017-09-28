using UnityEngine;

public class Timer : MonoBehaviour
{
   private float m_Timer;
   [SerializeField]
   private float m_TimeLimit = 5;

    void Update ()
    {
        m_Timer += Time.deltatime;
        
        if(m_Timer >= m_TimeLimit)
        {
            print("Your code");
            m_Timer = 0; // Restart timer
        }
    }
}
