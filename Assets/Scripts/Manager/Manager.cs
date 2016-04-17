using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Manager : MonoBehaviour
{
	private static readonly List<System.Type> _LoadedManagers = new List<System.Type> ();

	Coroutine _Updater;

	public void Init ()
	{
		// Confirm that each type of manager exists only one
		if (_LoadedManagers.Contains (this.GetType ()))
		{
			Debug.LogError ("[ERR] Duplicate manager loaded");
		}
		_LoadedManagers.Add (this.GetType ());

		OnInit ();

		StartFrameUpdate ();
	}

	private void StartFrameUpdate ()
	{
		if (_Updater != null)
		{
			StopCoroutine (_Updater);
		}
		_Updater = StartCoroutine (UpdateFrame ());
	}

	protected abstract void OnInit ();

	protected virtual IEnumerator UpdateFrame ()
	{
		yield break;
	}
}
