using UnityEngine;
using System.Collections;

public class EnemyPawn : Pawn
{
	protected override void Init ()
	{
		StartCoroutine (Think ());
	}

	IEnumerator Think ()
	{
		while (true)
		{
			yield return new WaitForSeconds (1.0F);

			Move (GetRandomDirection ());
		}
	}

	Vector3 GetRandomDirection ()
	{
		int direction = UnityEngine.Random.Range (0, 4);
		Vector3 result = Vector3.zero;

		switch (direction)
		{
		case 0:
			result = Vector3.left;
			break;

		case 1:
			result = Vector3.forward;
			break;

		case 2:
			result = Vector3.right;
			break;

		case 3:
			result = Vector3.back;
			break;

		default:
			Debug.LogError ("Invalid random");
			break;
		}

		return result;
	}
}
