using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;


public class EventName
{
	public const string START_LEVEL = "START_LEVEL";
	public const string MOVE_TO = "MOVE_TO";
}

public class EventManager : Manager
{
	private readonly Dictionary<string, List<EventCallback>> _Map = new Dictionary<string, List<EventCallback>> ();
	private readonly Dictionary<string, List<EventCallback>> _Map_Once = new Dictionary<string, List<EventCallback>> ();

	protected override void OnInit ()
	{
		// Ready for restart frontend without kill it
		// Should not needed, though
		_Map.Clear ();
		_Map_Once.Clear ();
	}

	public void InvokeEvent (string eventSring, EventData data = null)
	{
		if (_Map.ContainsKey (eventSring))
		{
			_Map [eventSring].ForEach (x => x (data));
		}

		if (_Map_Once.ContainsKey (eventSring))
		{
			_Map_Once [eventSring].ForEach (x => x (data));
			_Map_Once [eventSring].Clear ();
		}
	}

	public void AddEventListener (string eventString, EventCallback callback)
	{
		if (!_Map.ContainsKey (eventString))
		{
			_Map.Add (eventString, new List<EventCallback> ());
		}

		_Map [eventString].Add (callback);
	}

	public void AddOnceEventListener (string eventString, EventCallback callback)
	{
		if (!_Map_Once.ContainsKey (eventString))
		{
			_Map_Once.Add (eventString, new List<EventCallback> ());
		}

		_Map_Once [eventString].Add (callback);
	}

	public void RemoveEventListener (string eventString, EventCallback callback)
	{
		if (_Map.ContainsKey (eventString))
		{
			if (_Map [eventString].Contains (callback))
			{
				_Map [eventString].Remove (callback);
			}
		}

		if (_Map_Once.ContainsKey (eventString))
		{
			if (_Map_Once [eventString].Contains (callback))
			{
				_Map_Once [eventString].Remove (callback);
			}
		}
	}
}
