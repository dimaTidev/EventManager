//https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events#
using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class EventManager : MonoBehaviour
{
    Dictionary<string, UnityEvent> eventDictionary;
    static EventManager m_instance;

    static EventManager Instance
    {
        get
        {
            if (!m_instance)
            {
                m_instance = new GameObject("EventManager_Singleton").AddComponent<EventManager>();
                m_instance.eventDictionary = new Dictionary<string, UnityEvent>();
            }

            return m_instance;
        }
    }

    private void OnDestroy() => m_instance = null;

    public static void Start_Listening(string eventName, UnityAction listener)
    {
        if (Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
            thisEvent.AddListener(listener);
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public static void Stop_Listening(string eventName, UnityAction listener)
    {
        if (m_instance && Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
            thisEvent?.RemoveListener(listener);
    }

    public static void Trigger_Event(string eventName)
    {
        if (m_instance && Instance.eventDictionary.TryGetValue(eventName, out UnityEvent thisEvent))
            thisEvent?.Invoke();
    }
}