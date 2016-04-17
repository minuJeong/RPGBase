using UnityEngine;
using System.Collections;


public abstract class DataModel
{
}

/// CONFIG DATA
public class CONFIG : ScriptableObject
{
}


/// EVENT HANDLING

public delegate void EventCallback (EventData data);

public class EventData : DataModel
{
}

public class LevelStartEventData : EventData
{
}

public class MoveToEventData : EventData
{
	public string _SceneName = "";
	public string _GateName = "";

	public MoveToEventData (string sceneName, string gateName)
	{
		_SceneName = sceneName;
		_GateName = gateName;
	}
}
