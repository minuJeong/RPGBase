using UnityEngine;
using System.Collections;

public abstract class Manager : MonoBehaviour
{
	Coroutine _Updater;

	public void Init (InitLevelData data)
	{
		OnInit (data);

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

	protected abstract void OnInit (InitLevelData data);

	protected abstract IEnumerator UpdateFrame ();
}
