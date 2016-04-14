using UnityEngine;
using System.Collections;

/// <summary>
/// Will execute Init and will destroyed
/// </summary>
public abstract class EventMarker : MonoBehaviour
{
	protected virtual void Start ()
	{
		Init ();

		gameObject.SetActive (false);
	}

	protected abstract void Init ();
}
