using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GateManager : Manager
{
	// TODO: load level map data file
	// Dictionary<string, Dictionary<string, Vector3>> _GateID2PosMap = new Dictionary<string, Dictionary<string, Vector3>> ();

	protected override void OnInit (InitLevelData data)
	{
		// Do nothing
	}

	protected override IEnumerator UpdateFrame ()
	{
		yield break;
	}
}
