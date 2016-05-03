using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AstarMotor : MonoBehaviour
{
	// public
	public float Speed = 1.0F;
	public float StopDistance = 0.1F;

	public List<AstarTile> Path;

	// private
	AstarManager _AstarManager;

	Coroutine _CoroutineMovement;

	void Start ()
	{
		_AstarManager = Game.Instance.GetManager<AstarManager> ();
	}

	/// <summary>
	/// Start move to position
	/// </summary>
	/// <param name="toPos">To position.</param>
	public void SetDestination (Vector3 toPos)
	{
		if (_CoroutineMovement != null)
		{
			StopCoroutine (_CoroutineMovement);
		}

		// Consider arrived
		if (Vector3.Distance (transform.position, toPos) < StopDistance)
		{
			transform.position = toPos;
			Path.Clear ();
			return;
		}

		Path = GetPathTo (toPos);

		_CoroutineMovement = StartCoroutine (Movement ());
	}

	IEnumerator Movement ()
	{
		Queue<AstarTile> movePath = new Queue<AstarTile> ();
		Path.ForEach ((AstarTile tile) => movePath.Enqueue (tile));
		AstarTile target = movePath.Dequeue ();

		while (true)
		{
			yield return null;

			Vector3 delta = target.transform.position - transform.position;

			if (delta.magnitude < StopDistance)
			{
				transform.position = target.transform.position;

				if (movePath.Count == 0)
				{
					target = null;
					yield break;
				} else
				{
					target = movePath.Dequeue ();
					continue;
				}
			}

			transform.position += delta.normalized * Time.deltaTime * Speed;
		}
	}

	/// <summary>
	/// Shortcut to astar manager
	/// </summary>
	/// <returns>The path to.</returns>
	/// <param name="toPos">To position.</param>
	public List<AstarTile> GetPathTo (Vector3 toPos)
	{
		AstarTile fromTile = PositionToTile (transform.position);
		AstarTile toTile = PositionToTile (toPos);

		return _AstarManager.GetPathTo (fromTile, toTile);
	}

	/// <summary>
	/// Shortcut to astar manager
	/// </summary>
	public AstarTile PositionToTile (Vector3 position)
	{
		return _AstarManager.PositionToTile (position);
	}
}
