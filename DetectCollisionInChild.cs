using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGameObjectFather : MonoBehaviour
{
    [SerializeField] private GameObject m_GameObjectChild;

    private void Awake()
    {
        m_GameObjectChild.AddComponent<ScriptGameObjectChild>();
    }

}

public class ScriptGameObjectChild : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        print("Your code");
    }

    private void OnTriggerExit(Collider other)
    {
        print("Your code");
    }

    private void OnTriggerStay(Collider other)
    {
        print("Your code");
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Your code");
    }

    private void OnCollisionExit(Collision collision)
    {
        print("Your code");
    }

    private void OnCollisionStay(Collision collision)
    {
        print("Your code");
    }
}
