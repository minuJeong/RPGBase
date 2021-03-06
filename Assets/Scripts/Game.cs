﻿using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Game : MonoBehaviour
{
	public static Game Instance;

	public PlayerPawn _PlayerPawn
	{
		get
		{
			return GetPlayerPawn ();
		}
	}

	public List<Manager> _Managers = new List<Manager> ();

	private Coroutine _FrameUpdater;

	public GameObject _MoveTargetIndicator_PREFAB;


	// Use this for initialization
	void Awake ()
	{
		Instance = this;

		DontDestroyOnLoad (gameObject);

		_Managers.AddRange (transform.GetComponentsInChildren<Manager> ());

		Init ();
	}

	public void Init ()
	{
		_Managers.ForEach (x => x.Init ());

		// Start frame update
		if (_FrameUpdater != null)
		{
			StopCoroutine (_FrameUpdater);
		}
		_FrameUpdater = StartCoroutine (FrameUpdate ());
	}

	/// <summary>
	/// find first matching manager (each type of manager should only exists one)
	/// </summary>
	public T GetManager<T> () where T : Manager
	{
		T result = _Managers.Find (manager => (manager as T) != null) as T;
		if (result != null)
		{
			return result;
		}

		Debug.LogError ("Should not happen");
		return null;
	}

	/// <summary>
	/// Shortcut player pawn
	/// </summary>
	public PlayerPawn GetPlayerPawn ()
	{
		return Game.Instance.GetManager<PawnManager> ()._PlayerPawn;
	}

	/// <summary>
	/// Shortcut event manager
	/// </summary>
	public void DispatchEvent (string eventString, EventData eventData = null)
	{
		GetManager<EventManager> ().InvokeEvent (eventString, eventData);
	}

	/// <summary>
	/// Shortcut event manager
	/// </summary>
	public void AddEventListener (string eventString, EventCallback callback)
	{
		GetManager<EventManager> ().AddEventListener (eventString, callback);
	}

	/// <summary>
	/// Shortcut event manager
	/// </summary>
	public void AddOnceEventListener (string eventString, EventCallback callback)
	{
		GetManager<EventManager> ().AddOnceEventListener (eventString, callback);
	}

	// Handle User Input
	IEnumerator FrameUpdate ()
	{
		while (true)
		{
			yield return null;

			if (_PlayerPawn == null)
			{
				continue;
			}

			/*
			 * When using this, you better use nav mesh agent for pawn
			float x = Input.GetAxis ("Horizontal");
			float z = Input.GetAxis ("Vertical");
			if (x * x + z * z > 0.0F)
			{
				_PlayerPawn.Move (new Vector3 (x, 0, z));
			}
			*/

			if (Input.GetMouseButtonDown (0))
			{
				Ray ray = GetManager<CameraManager> ().MainCamera.ScreenPointToRay (Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit))
				{
					if (hit.collider.GetComponent<AstarTile> () == null)
					{
						continue;
					}

					CommandMove (hit);
				}
			}

			// Control Attack
			if (Input.GetKey (KeyCode.Space) || Input.GetKeyDown (KeyCode.Z))
			{
				_PlayerPawn.Attack ();
			}

		}
	}

	void CommandMove (RaycastHit hit)
	{
		// Show Indicator
		if (_MoveTargetIndicator_PREFAB != null)
		{
			GameObject indicator = Instantiate (_MoveTargetIndicator_PREFAB);
			indicator.transform.position = hit.collider.transform.position;
		}
		
		// Pawn MoveTo point
		Vector3 pos = hit.point;
		pos.y = 0.0F;
		_PlayerPawn.MoveTo (pos);
	}
}
