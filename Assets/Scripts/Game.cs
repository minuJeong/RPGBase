using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
	public static Game Instance;

	public PlayerPawn _Pawn;

	// Use this for initialization
	void Start ()
	{
		Instance = this;

		Debug.Assert (_Pawn != null);
	}
	
	// Handle User Input
	void Update ()
	{
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		_Pawn.Move (new Vector3(x, 0, z));

		/// Control Attack
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Z))
		{
			_Pawn.Attack ();
		}
	}
}
