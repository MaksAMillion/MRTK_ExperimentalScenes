using HoloToolkit.Unity.InputModule;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    public uint _handId;
    public SourceStateEventData handEventData;
    public bool handDetected = false;
    public IInputSource source;
    public GameObject equipped;
    public DateTime time = new DateTime();
}
