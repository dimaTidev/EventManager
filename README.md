Simple event Manager `string based` without args

In my GitHub you can find another [scriptableObject based eventManager](https://github.com/dimaTidev/GameEvents)

## How to use

Drag&Drop `EventManager_Broker.cs` and setup\
Or call 
```C#
EventManager.Start_Listening(string, UnityAction); //will automatically create manager
EventManager.Stop_Listening(string eventName, UnityAction listener);
EventManager.Trigger_Event(string eventName);
EventManager_Broker.OnCall(); //will automatically create manager
```

> `EventManager` will automatically create at first call `Start_Listening`. You don't have to care about creating manager.

## Links
[unity learn](https://learn.unity.com/tutorial/create-a-simple-messaging-system-with-events#)
