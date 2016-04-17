using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public sealed class GateManager : Manager
{
	private List<GateLocation> _Gates = new List<GateLocation> ();

	protected override void OnInit ()
	{
		Game.Instance.AddEventListener (EventName.START_LEVEL, OnStartLevel);
		Game.Instance.AddEventListener (EventName.MOVE_TO, OnMoveTo);
	}

	protected override IEnumerator UpdateFrame ()
	{
		yield break;
	}

	void OnStartLevel (EventData data)
	{
		var e = data as LevelStartEventData;
		if (e == null)
		{
			return;
		}

		_Gates.Clear ();
		_Gates.AddRange (FindObjectsOfType<GateLocation> ());
	}

	void OnMoveTo (EventData data)
	{
		// Data required
		var e = data as MoveToEventData;
		if (e == null)
		{
			return;
		}

		if (string.IsNullOrEmpty (e._SceneName))
		{
			if (string.IsNullOrEmpty (e._GateName))
			{
				return;
			}

			MoveToGate (e._GateName);
		}
		else
		{
			EventCallback moveToGateAfterLoadLevel = (evd) => MoveToGate (e._GateName);

			Game.Instance.AddOnceEventListener (EventName.START_LEVEL, moveToGateAfterLoadLevel);

			Game.Instance.GetManager<LevelManager> ().LoadLevel (e);
		}
	}

	void MoveToGate (string gateID)
	{
		GateLocation gate = _Gates.Find (x => x._GateID == gateID);

		if (gate == null)
		{
			Debug.LogError ("Can't find gateID: " + gateID);

			return;	
		}

		Game.Instance._PlayerPawn.transform.position = gate.transform.position;
	}
}
