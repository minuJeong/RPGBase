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
		/// Control Movement
		List<Vector3> dirs = new List<Vector3> ();

		if (Input.GetKey (KeyCode.LeftArrow))
		{
			dirs.Add (Vector3.left);
		}

		if (Input.GetKey (KeyCode.UpArrow))
		{
			dirs.Add (Vector3.forward);
		}

		if (Input.GetKey (KeyCode.RightArrow))
		{
			dirs.Add (Vector3.right);
		}

		if (Input.GetKey (KeyCode.DownArrow))
		{
			dirs.Add (Vector3.back);
		}

		if (dirs.Count != 0)
		{
			Vector3 dir = Vector3.zero;
			dirs.ForEach (v =>
			{
				dir += v;
			});

			_Pawn.Move (dir.normalized);
		}


		/// Control Attack
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.Z))
		{
			_Pawn.Attack ();
		}
	}
}
