using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public sealed class AstarManager : Manager
{
	public enum WALK_TYPE
	{
		WAY_4,
		WAY_8
	}

	public enum EXPAND_RESULT
	{
		CONTINUE,
		ARRIVE,
		BLOCKED
	}

	public WALK_TYPE WalkType = WALK_TYPE.WAY_4;

	// data
	Dictionary<Vector2, AstarTile> _Tiles = null;

	protected override void OnInit ()
	{
		Game.Instance.AddEventListener (EventName.START_LEVEL, OnStartLevel);
	}

	private void OnStartLevel (EventData data)
	{
		SetupTiles ();
	}

	private void SetupTiles ()
	{
		// gather..
		_Tiles = new Dictionary<Vector2, AstarTile> ();
		new List<AstarTile> (FindObjectsOfType<AstarTile> ()).ForEach ((AstarTile tile) =>
		{
			// reset path parent
			tile.PathParent = null;

			if (!_Tiles.ContainsKey (tile.XZ))
			{
				_Tiles.Add (tile.XZ, tile);
			}
			else
			{
				Debug.Log (string.Format ("Tile Duplicated: {0}, {1}", tile, _Tiles [tile.XZ]));
			}
		});
	}

	public List<AstarTile> GetPathTo (AstarTile start, AstarTile destination)
	{
		Debug.Log ("Get Path To called");

		List<AstarTile> paths = new List<AstarTile> ();

		List<AstarTile> closeSet = new List<AstarTile> ();
		List<AstarTile> openSet = new List<AstarTile> ();
		AstarTile currentCursor = start;

		// open/close
		Func<AstarTile, bool> open = (AstarTile cursor) =>
		{
			if (cursor == null || !cursor.IsWalkable)
			{
				return false;
			}

			if (cursor.XZ == destination.XZ)
			{
				return true;
			}

			openSet.Add (cursor);
			return false;
		};

		Action<AstarTile> close = (AstarTile cursor) =>
		{
			openSet.Remove (cursor);
			closeSet.Add (cursor);
		};

		// Scoring
		Func<AstarTile, float> G = (AstarTile cursor) => Vector2.Distance (cursor.XZ, start.XZ);
		Func<AstarTile, float> H = (AstarTile cursor) => Vector2.Distance (cursor.XZ, destination.XZ);
		Func<AstarTile, float> F = (AstarTile cursor) => G (cursor) + H (cursor);

		Func<AstarTile, EXPAND_RESULT> expand = (AstarTile cursor) =>
		{
			if (cursor.XZ == destination.XZ)
			{
				return EXPAND_RESULT.ARRIVE;
			}

			close (cursor);

			List<Vector2> nextCursors = new List<Vector2> ();
			switch (WalkType)
			{
			case WALK_TYPE.WAY_4:
				nextCursors.Add (cursor.XZ + Vector2.left);
				nextCursors.Add (cursor.XZ + Vector2.up);
				nextCursors.Add (cursor.XZ + Vector2.right);
				nextCursors.Add (cursor.XZ + Vector2.down);
				break;

			case WALK_TYPE.WAY_8:
				nextCursors.Add (cursor.XZ + Vector2.left);
				nextCursors.Add (cursor.XZ + Vector2.up);
				nextCursors.Add (cursor.XZ + Vector2.right);
				nextCursors.Add (cursor.XZ + Vector2.down);
				nextCursors.Add (cursor.XZ + Vector2.left + Vector2.up);
				nextCursors.Add (cursor.XZ + Vector2.right + Vector2.up);
				nextCursors.Add (cursor.XZ + Vector2.left + Vector2.down);
				nextCursors.Add (cursor.XZ + Vector2.right + Vector2.down);
				break;
			}

			// open if exists
			bool isDestination = false;
			nextCursors.ForEach (nCursor =>
			{
				// Skip if nCursor is closed
				if (closeSet.Find ((AstarTile closedTile) => closedTile.XZ == nCursor) != null)
				{
					return;
				}

				if (_Tiles.ContainsKey (nCursor))
				{
					_Tiles [nCursor].PathParent = currentCursor;
					isDestination = open (_Tiles [nCursor]);
				}
			});

			if (isDestination)
			{
				return EXPAND_RESULT.ARRIVE;
			}

			if (openSet.Count == 0)
			{
				return EXPAND_RESULT.BLOCKED;
			}

			float minScore = float.MaxValue;
			AstarTile minTile = currentCursor;
			openSet.ForEach ((AstarTile tile) =>
			{
				float score = F (tile);
				if (score < minScore)
				{
					minScore = score;
					minTile = tile;
				}
			});

			currentCursor = minTile;

			return EXPAND_RESULT.CONTINUE;
		};


		open (start);
		int escape = 30;
		while (expand (currentCursor) == EXPAND_RESULT.CONTINUE)
		{
			Debug.Log ("PATH_EXPANDING......");

			Debug.Break ();

			if (escape-- == 0)
			{
				Debug.Log ("Safe Escape");
				paths.Clear ();
				return paths;
			}
		}

		Action<AstarTile> pathsCatcher;
		pathsCatcher = (AstarTile tile) =>
		{
			Debug.Log ("Catching Path");
			paths.Add (tile);
			if (tile.PathParent != null)
			{
				pathsCatcher (tile.PathParent);
			}
		};
		pathsCatcher (destination);
		paths.Reverse ();

		return paths;
	}

	/// <summary>
	/// Get closest tile from position
	/// </summary>
	public AstarTile PositionToTile (Vector3 position)
	{
		if (_Tiles == null || _Tiles.Count == 0)
		{
			Debug.LogError ("_Tiles not initialized");
			
			return null;
		}

		Vector2 key = new Vector2 (position.x, position.z);
		if (!_Tiles.ContainsKey (key))
		{
			float closestDistance = float.MaxValue;
			AstarTile closestTile = null;
				
			var e = _Tiles.Keys.GetEnumerator ();
			while (e.MoveNext ())
			{
				float distance = Vector2.Distance (key, e.Current);

				if (closestTile == null)
				{
					closestDistance = distance;
					closestTile = _Tiles [e.Current];
				}
				else
				if (distance < closestDistance)
				{
					closestDistance = distance;
					closestTile = _Tiles [e.Current];
				}
			}
			
			return closestTile;
		}
		return _Tiles [key];
	}
}
