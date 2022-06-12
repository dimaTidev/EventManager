using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager_Broker : MonoBehaviour
{
    public enum InvokeState { OnEnable, OnDisable, OnAwake, OnStart, OnCall}
    [SerializeField] InvokeState invokeState = InvokeState.OnAwake;
    [SerializeField] string eventKey = "";

    void OnEnable()
    {
        if(invokeState == InvokeState.OnEnable)
            EventManager.Trigger_Event(eventKey);
    }
    void OnDisable()
    {
        if (invokeState == InvokeState.OnDisable)
            EventManager.Trigger_Event(eventKey);
    }
    void Awake()
    {
        if (invokeState == InvokeState.OnAwake)
            EventManager.Trigger_Event(eventKey);
    }
    void Start()
    {
        if (invokeState == InvokeState.OnStart)
            EventManager.Trigger_Event(eventKey);
    }

    public void OnCall() => EventManager.Trigger_Event(eventKey);
}
