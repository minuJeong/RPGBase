using UnityEngine;
using System.Collections;

public class PlayerPawn_View_AnimParams : MonoBehaviour
{
	Animator _Mecanim;
	Vector3 _LastPosition;

	// Use this for initialization
	void Start ()
	{
		_Mecanim = GetComponent<Animator> ();
		Debug.Assert (_Mecanim != null);

		_UpdatePosition ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		_UpdateSpeed ();
		_UpdatePosition ();
	}

	void _UpdateSpeed ()
	{
		Vector3 delta = transform.position - _LastPosition;
		_Mecanim.SetFloat ("MoveSpeed", delta.magnitude / Time.deltaTime);
		Debug.Log (delta.magnitude / Time.deltaTime);
	}

	void _UpdatePosition ()
	{
		_LastPosition = transform.position;
	}
}
