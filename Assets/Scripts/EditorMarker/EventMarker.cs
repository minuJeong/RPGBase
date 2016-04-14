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

		Destroy (gameObject);
	}

	protected abstract void Init ();
}
