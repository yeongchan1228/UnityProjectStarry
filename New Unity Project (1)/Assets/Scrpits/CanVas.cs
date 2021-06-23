using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanVas : MonoBehaviour
{
    void Awake()

    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Screen.SetResolution(1280, 720, true);
    }
}
