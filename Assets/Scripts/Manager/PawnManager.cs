using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Collections.Generic;

public sealed class PawnManager : Manager
{
	public PlayerPawn _PlayerPawnPrefab;

	[HideInInspector]
	public PlayerPawn _PlayerPawn;

	[HideInInspector]
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

			StartLocation startLocation = FindObjectOfType<StartLocation> ();
			if (startLocation != null)
			{
				_PlayerPawn.transform.position = startLocation.transform.position;
			}
		};

		Game.Instance.AddEventListener (EventName.START_LEVEL, SpawnPlayerPawn);
	}
}
