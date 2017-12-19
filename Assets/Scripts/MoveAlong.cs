using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class MoveAlong : MonoBehaviour, IInputClickHandler {
    private InputManager inputManager;

    private void Start()
    {
        inputManager = InputManager.Instance;

        if (inputManager != null)
        {
            inputManager.OverrideFocusedObject = gameObject;
        }

        
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        if (inputManager != null)
        {
            gameObject.transform.Rotate(0, 10, 0);
            inputManager.OverrideFocusedObject = null;
        }
        
    }
}
