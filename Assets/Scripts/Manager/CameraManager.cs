using UnityEngine;
using System.Collections;

public class CameraManager : Manager
{
	PlayerPawn _Pawn;

	Coroutine _Updater;

	protected override void OnInit (InitLevelData data)
	{
		_Pawn = data._Pawn;

		transform.position = _Pawn.transform.position;

		if (_Updater != null)
		{
			StopCoroutine (_Updater);
		}
		_Updater = StartCoroutine (UpdateFrame ());
	}
	
	// Update is called once per frame
	protected override IEnumerator UpdateFrame ()
	{
		while (true)
		{
			yield return null;

			if (_Pawn == null)
			{
				yield break;
			}

			transform.position = Vector3.Lerp (transform.position, _Pawn.transform.position, 0.1F);
		}
	}
}
