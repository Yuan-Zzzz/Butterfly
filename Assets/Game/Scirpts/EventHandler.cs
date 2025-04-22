using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    public static Action<bool> playableEvent;

    public static void Call_playableEvent(bool isTrue)
    {
        playableEvent.Invoke(isTrue);
    }
}
