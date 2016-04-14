using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
	public static Game Instance;


	[HideInInspector]
	public PlayerPawn _Pawn;

	public CameraControl _MainCamera;

	// Use this for initialization
	void Awake ()
	{
		Instance = this;

		Debug.Assert (_MainCamera != null);
	}


	public void Init (PlayerPawn pawn)
	{
		_Pawn = pawn;

		_MainCamera.Init (pawn);

		StartCoroutine (OnEnterFrame ());
	}
	
	// Handle User Input
	IEnumerator OnEnterFrame ()
	{
		while (true)
		{
			yield return null;

			float x = Input.GetAxis ("Horizontal");
			float z = Input.GetAxis ("Vertical");

			_Pawn.Move (new Vector3 (x, 0, z));

			/// Control Attack
			if (Input.GetKey (KeyCode.Space) || Input.GetKeyDown (KeyCode.Z))
			{
				_Pawn.Attack ();
			}
		}
	}
}
