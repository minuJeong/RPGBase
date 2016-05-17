using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MoveLocation : EventMarker
{
	protected BoxCollider _Area;

	[SerializeField]
	protected string _ToScene;

	[SerializeField]
	protected string _ToGate;

	protected override void Init ()
	{
		_Area = GetComponent<BoxCollider> ();

		Debug.Assert (_Area != null);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent<PlayerPawn> () == null)
		{
			return;
		}

		Game.Instance.DispatchEvent (EventName.MOVE_TO, new MoveToEventData (_ToScene, _ToGate));
	}
}
