using UnityEngine;
using System.Collections;

public class StartLocation : EventMarker
{
	public PlayerPawn _PawnPrefab;

	protected override void Init ()
	{
		Debug.Assert (_PawnPrefab != null);

		SetupPawn ();
	}

	void SetupPawn ()
	{
		PlayerPawn pawn = Instantiate (_PawnPrefab);

		pawn.transform.position = transform.position;

		Game.Instance.Init (pawn);
	}
}
