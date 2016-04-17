using UnityEngine;
using System.Collections;

public sealed class CameraManager : Manager
{
	PlayerPawn __TargetPawn;

	public PlayerPawn _TargetPawn
	{
		get
		{
			return __TargetPawn;
		}

		set
		{
			Debug.Assert (value != null);

			__TargetPawn = value;

			transform.position = _TargetPawn.transform.position;
		}
	}

	Coroutine _Updater;

	protected override void OnInit ()
	{
		if (_Updater != null)
		{
			StopCoroutine (_Updater);
		}
		_Updater = StartCoroutine (UpdateFrame ());

		Game.Instance.AddEventListener (EventName.START_LEVEL, OnStartLevel);
	}
	
	// Update is called once per frame
	protected override IEnumerator UpdateFrame ()
	{
		while (true)
		{
			yield return null;

			if (_TargetPawn == null)
			{
				continue;
			}

			transform.position = Vector3.Lerp (transform.position, _TargetPawn.transform.position, 0.1F);
		}
	}

	void OnStartLevel (EventData data)
	{
		_TargetPawn = Game.Instance._PlayerPawn;
	}
}
