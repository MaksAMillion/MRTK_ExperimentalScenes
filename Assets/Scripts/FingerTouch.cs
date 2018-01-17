using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FingerTouch : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObjectPickup>())
        {
            Debug.Log("Object pick up should be picked up ... OnCollision Enter -- FingerTouch.cs");
        }
    }
}
