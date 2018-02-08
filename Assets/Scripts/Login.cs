using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Login : MonoBehaviour, ISpeechHandler
{
    BoxCollider bcFrame;
    public GameObject loginPopUp;
    [SerializeField]
    private GameObject cursor;

    private void Start()
    {
        bcFrame = GetComponent<BoxCollider>();

        if (bcFrame != null)
        {
            bcFrame.enabled = false;
        }

        cursor = GameObject.FindGameObjectWithTag("cursor");
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "IndexFinger")
        {
            Debug.Log("This is colliding with object tagged IndexFinger-- testing frame collision login.cs");
            // The login ui should be activated in this method
        }
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        string speechText;

        if (eventData.RecognizedText != null)
        {
            speechText = eventData.RecognizedText;

            if (speechText == "Hands Plus Plus")
            {
                Debug.Log("this is text i think " + eventData.RecognizedText);

                if (cursor != null)
                {
                    cursor.GetComponent<AnimatedCursor>().HandActive(true);
                }
            }
            
        }
        Debug.Log("This is the speech keyword recognized method in login.cs -- line 32");
    }
    
}
