using HoloToolkit.Unity;
using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager : Singleton<TouchManager>
{
    public GameObject cursorAcid;
    public Vector3 handPosition;

    [SerializeField]
    private GameObject _defaultLeftHand;
    [SerializeField]
    private GameObject _defaultRightHand;

    private GameObject currentLeftObject;
    private GameObject currentRightObject;

    private SourceStateEventData _leftHandDetectedEventData;
    private SourceStateEventData _rightHandDetectedEventData;
    public Hand _primaryHand;
    public Hand _secondaryHand;
    public IInputSource sourceLost;
    public IInputSource sourceFound;
    
	void Update ()
    {
        if (_primaryHand != null && _primaryHand.handEventData != null && _primaryHand.handDetected)
        {
            // uint sourceId = _primaryHand._handId;
            Vector3 position;
            
            if (_primaryHand.handEventData.InputSource.TryGetGripPosition(0, out position))
            {
                _defaultLeftHand.SetActive(true);
                _defaultLeftHand.transform.position = position;
            }
        }
        else if ((_primaryHand != null && !(_primaryHand.handDetected)) || _primaryHand == null)
        {
            _defaultLeftHand.SetActive(false);
        }

        if (_secondaryHand != null && _secondaryHand.handEventData != null && _secondaryHand.handDetected)
        {
            // uint sourceId = _secondaryHand._handId;
            Vector3 position, secondaryPosition;
            
            if (_secondaryHand.handEventData.InputSource.TryGetGripPosition(0, out position))
            {
                _defaultRightHand.SetActive(true);
                _defaultRightHand.transform.position = position;
            }
        }
        else if ((_secondaryHand != null && !(_secondaryHand.handDetected)) || _secondaryHand == null)
        {
            _defaultRightHand.SetActive(false);
        }
    }

    public void SetSourceStateEventData(SourceStateEventData eventData, uint visibleHandsCount)
    {
        if (visibleHandsCount == 0)
        {
            _primaryHand = null;
            _secondaryHand = null;
        }
        else if (visibleHandsCount == 1)
        {
            // a hand has lost tracking
            if (_secondaryHand != null && !(_secondaryHand.handDetected))
            {
                Vector3 primarySourcePosition, secondarySourcePosition, eventDataSourcePosition;

                _primaryHand.handEventData.InputSource.TryGetGripPosition(0, out primarySourcePosition);
                _secondaryHand.handEventData.InputSource.TryGetGripPosition(0, out secondarySourcePosition);
                eventData.InputSource.TryGetGripPosition(eventData.SourceId, out eventDataSourcePosition);

                Debug.Log("Primary hand position: " + primarySourcePosition);
                Debug.Log("Secondary hand position: " + secondarySourcePosition);
                Debug.Log("Event hand position: " + eventDataSourcePosition);

                if (primarySourcePosition == eventDataSourcePosition)
                {
                    _primaryHand = _secondaryHand;
                }
                // else if (secondarySourcePosition == eventDataSourcePosition)
                // {

                //}
                
                // _primaryHand = _secondaryHand;
                // _primaryHand.handEventData = _secondaryHand.handEventData;
                
                _secondaryHand = null;
            }
            else if (_secondaryHand == null)
            {
                _primaryHand.handEventData = eventData;
            }
        }
        else if (visibleHandsCount == 2)
        {
            // _primaryHand.handEventData = eventData;
            _secondaryHand.handEventData = eventData;

            Vector3 primarySourcePosition, secondarySourcePosition, eventDataSourcePosition;
        }
    }
    
    public void SetHandDetected(bool handDetected, uint visibleHandsDetected)
    {
        if (handDetected)
        {
            if (visibleHandsDetected == 1)
            {
                _primaryHand = new Hand();
                _primaryHand.handDetected = handDetected;
                _primaryHand._handId = 0;

                _secondaryHand = null;
            }
            else if (visibleHandsDetected == 2)
            {
                _secondaryHand = new Hand();
                _secondaryHand.handDetected = handDetected;
                _secondaryHand._handId = 1;
            }
        }
        else if (!handDetected)
        {
            if (visibleHandsDetected == 1)
            {
                _primaryHand.handDetected = !handDetected;
                _secondaryHand.handDetected = handDetected;
            }
            else if (visibleHandsDetected == 0)
            {
                _primaryHand = null;
                _secondaryHand = null;
            }
        }
    }
}