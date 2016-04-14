using UnityEngine;
using UnityEngine.SceneManagement;
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

		InitLevelData data = new InitLevelData ();
		data._Pawn = pawn;
		data._CurrentSceneName = SceneManager.GetActiveScene().name;

		Game.Instance.Init (data);
	}
}
