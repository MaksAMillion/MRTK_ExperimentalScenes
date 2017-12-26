using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : HoloToolkit.Unity.InputModule.Cursor
{
    public bool handDetected;
    public GameObject currentObject;
    public GameObject cursorAcid;
    public Vector3 handPosition;

	// Use this for initialization
	void Start () {
        handDetected = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (handDetected)
        {
            Debug.Log("Hande detected is: " + handDetected);

        }

    }

}
