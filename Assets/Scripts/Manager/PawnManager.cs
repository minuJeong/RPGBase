using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public sealed class PawnManager : Manager
{
	[SerializeField]
	PlayerPawn _PlayerPawnPrefab;

	public PlayerPawn _PlayerPawn;

	public List<Pawn> _AllPawns = new List<Pawn> ();


	public Pawn SpawnPawn (Pawn pawn)
	{
		Pawn _pawn = Instantiate (pawn);

		_AllPawns.Add (_pawn);

		return _pawn;
	}

	protected override void OnInit ()
	{
		Debug.Assert (_PlayerPawnPrefab != null);
		EventCallback SpawnPlayerPawn = (EventData e) =>
		{
			_PlayerPawn = SpawnPawn (_PlayerPawnPrefab) as PlayerPawn;

			_PlayerPawn.transform.position = FindObjectOfType<StartLocation> ().transform.position;
		};

		Game.Instance.AddEventListener (EventName.START_LEVEL, SpawnPlayerPawn);
	}
}
