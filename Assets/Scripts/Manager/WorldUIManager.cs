using UnityEngine;
using System.Collections;


public enum WUI_TYPES
{
	MOVE_COMMAND,
}

public class WorldUIManager : Manager
{
	[SerializeField]
	GameObject MoveCommandIndicatorPrefab;

	GameObject MoveCommandIndicator;

	protected override void OnInit ()
	{
		if (MoveCommandIndicator == null)
		{
			Debug.Assert (MoveCommandIndicatorPrefab != null);

			MoveCommandIndicator = Instantiate<GameObject> (MoveCommandIndicatorPrefab);
			MoveCommandIndicator.SetActive (false);
		}
	}

	/// <summary>
	/// Return could be null
	/// </summary>
	/// <param name="wuiType">Wui type.</param>
	public GameObject Put (WUI_TYPES wuiType)
	{
		switch (wuiType)
		{
		case WUI_TYPES.MOVE_COMMAND:

			MoveCommandIndicator.SetActive (true);
			return MoveCommandIndicator;
		}

		return null;
	}
}
