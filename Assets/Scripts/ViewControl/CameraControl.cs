using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	Vector3 _Offset;

	PlayerPawn _Pawn;

	public void Init (PlayerPawn pawn)
	{
		_Pawn = pawn;

		_Offset = _Pawn.transform.position - transform.position;

		StartCoroutine (OnEnterFrame ());	
	}
	
	// Update is called once per frame
	IEnumerator OnEnterFrame ()
	{
		while (true)
		{
			yield return null;

			Vector3 lerpTo = _Pawn.transform.position - _Offset;

			transform.position = Vector3.Lerp (transform.position, lerpTo, 0.1F);
		}
	}
}
