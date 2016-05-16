using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;

public class AstarUtil : EditorWindow
{
	[MenuItem ("RBaseTools/EditorExtension/AstarUtil #%k")]
	public static void OpenWindow ()
	{
		EditorWindow.GetWindow<AstarUtil> ();
	}

	void OnGUI ()
	{
		if (GUILayout.Button ("FindDuplicates"))
		{
			var duplicateMap = new Dictionary<Vector2, AstarTile> ();

			var tiles = FindObjectsOfType<AstarTile> ();
			Array.ForEach (tiles, x =>
			{
				x.gameObject.name = "Tile_" + x.XZ;

				if (duplicateMap.ContainsKey (x.XZ))
				{
					Debug.LogError ("Duplicate tile: " + x + x.XZ + ", " + duplicateMap [x.XZ] + duplicateMap [x.XZ].XZ);

					Selection.activeGameObject = x.gameObject;
				}
				else
				{
					duplicateMap.Add (x.XZ, x);
				}
			});
		}
	}
}
