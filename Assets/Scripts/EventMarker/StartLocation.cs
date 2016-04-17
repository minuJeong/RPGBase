using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine.SceneManagement;
using System.Collections;

public class StartLocation : GateLocation
{
	protected override void Init ()
	{
		_GateID = "StartLocation";
	}
}

#if UNITY_EDITOR
[CustomEditor (typeof(StartLocation))]
public class StartLocationEditor : Editor
{
	public override void OnInspectorGUI ()
	{
		EditorGUILayout.LabelField (" - GateID = StartLocation");
	}
}
#endif