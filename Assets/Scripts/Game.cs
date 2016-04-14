using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
	public static Game Instance;

	[HideInInspector]
	public PlayerPawn _Pawn;

	public List<Manager> _Managers = new List<Manager> ();

	private Coroutine _FrameUpdater;

	// Use this for initialization
	void Awake ()
	{
		Instance = this;

		DontDestroyOnLoad (gameObject);

		Debug.Assert (_Managers.TrueForAll (x =>
		{
			return x != null;
		}));
	}


	/// <summary>
	/// Called by StartLocation
	/// </summary>
	/// <param name="pawn">Pawn.</param>
	public void Init (InitLevelData data)
	{
		// Init me
		_Pawn = data._Pawn;

		// Init managers
		InitLevelData model = new InitLevelData ();

		model._Pawn = data._Pawn;

		_Managers.ForEach (x =>
		{
			x.Init (model);
		});

		// Start frame update
		if (_FrameUpdater != null)
		{
			StopCoroutine (_FrameUpdater);
		}
		_FrameUpdater = StartCoroutine (FrameUpdate ());
	}


	public T GetManager<T> () where T : Manager
	{
		return _Managers.FindAll (manager =>
		{
			return (manager as T) != null;
		}) [0] as T;
	}

	
	// Handle User Input
	IEnumerator FrameUpdate ()
	{
		while (true)
		{
			yield return null;

			if (_Pawn == null)
			{
				yield break;
			}

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
