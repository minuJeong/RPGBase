using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
	[SerializeField]
	PlayerPawn _Target;

	Vector3 _Offset;

	// Use this for initialization
	void Start ()
	{
		Debug.Assert (_Target != null);

		_Offset = _Target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 lerpTo = _Target.transform.position - _Offset;

		transform.position = Vector3.Lerp (transform.position, lerpTo, 0.1F);
	}
}
