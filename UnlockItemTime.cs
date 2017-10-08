using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UnlockItemTime : MonoBehaviour
{
    DateTime m_Time = new DateTime();
    [SerializeField] private float timeWait;
    [SerializeField] private bool activeTime = false;

    private void StartTimeNow() // Call when it's necessary for you.
    {
        m_Time = DateTime.Now.AddMinutes(timeWait);
    }

    private void Update()
    {
        if (activeTime)
        {
            if (DateTime.Now >= m_Time)
            {
                print("You code!");
            }
            else
            {
                TimeSpan timeFinish = DateTime.Now.Subtract(m_Time);
                print("Time finish in:: " + timeFinish.TotalMinutes);
            }
        }
    }
}
