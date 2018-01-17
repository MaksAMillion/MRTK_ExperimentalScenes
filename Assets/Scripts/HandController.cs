using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    private Animator _handAnimator;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start () {
        _handAnimator = GetComponent<Animator>();
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update () {

	}

    public void HandGrab(bool grab)
    {
        if (_handAnimator == null)
        {
            return;
        }

        _handAnimator.SetBool("Grab", grab);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
}
