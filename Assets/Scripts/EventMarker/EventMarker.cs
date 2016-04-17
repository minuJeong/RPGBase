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
	}

	/// <summary>
	/// Use this instead of Start
	/// </summary>
	protected abstract void Init ();
}
