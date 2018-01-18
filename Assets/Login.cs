using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour
{
    BoxCollider bcFrame;

    private void Start()
    {
        bcFrame = GetComponent<BoxCollider>();

        if (bcFrame != null)
        {
            bcFrame.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "IndexFinger")
        {
            Debug.Log("This is colliding with object tagged IndexFinger-- testing frame collision login.cs");
        }
    }
}
