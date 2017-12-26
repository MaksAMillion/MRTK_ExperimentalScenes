using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : Singleton<TouchManager>
{
    public GameObject currentObject;
    public GameObject cursorAcid;
    public Vector3 handPosition;

    private bool _handDetected;
    private SourceStateEventData _handDetectedEventData;

	// Use this for initialization
	void Start () {
        _handDetected = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (_handDetected)
        {
            uint sourceId = _handDetectedEventData.SourceId;
            Vector3 position;
            //Quaternion orientation;

            if (_handDetectedEventData.InputSource.TryGetPointerPosition(sourceId, out position))
            {
                currentObject.SetActive(true);
                currentObject.transform.position = position;
            }

            /*
            if (_handDetectedEventData.InputSource.TryGetOrientation(sourceId, out orientation))
            {
                _equippableObject.transform.rotation = orientation;
            }
            */
        }
        else
        {
            currentObject.SetActive(false);
        }

    }

    public void SetSourceStateEventData(SourceStateEventData eventData)
    {
        _handDetectedEventData = eventData;
    }

    public void SetHandDetected(bool handDetected)
    {
        this._handDetected = handDetected;
    }

}
