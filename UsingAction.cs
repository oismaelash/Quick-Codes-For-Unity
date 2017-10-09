using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UsingAction : MonoBehaviour
{
    private Action myAction;
    
    private void Start()
    {
        myAction += CallMyAction;;

        if(2 > 1)
        {
            if (myAction != null) // .Net 3.5
            {
                myAction();
            }

            //myAction?.Invoke(); // .Net 4.6
        }
    }

    private void CallMyAction()
    {
        print("Call myAction");
    }
}
