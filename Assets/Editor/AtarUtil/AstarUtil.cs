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
		const float BUTTON_WIDTH = 220;
		const float BUTTON_HEIGHT = 32;

		var tiles = FindObjectsOfType<AstarTile> ();

		if (GUILayout.Button ("Rename Tiles", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			Array.ForEach (tiles, tile =>
			{
				tile.gameObject.name = "Tile_" + tile.XZ;
			});

			EditorUtility.DisplayDialog ("Message", "Rename Complete", "Ok");
		}

		if (GUILayout.Button ("Find Duplicates", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			var ErrorCount = 0;
			var duplicateMap = new Dictionary<Vector2, AstarTile> ();

			Array.ForEach (tiles, x =>
			{
				if (duplicateMap.ContainsKey (x.XZ))
				{
					Debug.LogError ("Duplicate tile: " + x + x.XZ + ", " + duplicateMap [x.XZ] + duplicateMap [x.XZ].XZ);

					Selection.activeGameObject = x.gameObject;
					ErrorCount++;
				}
				else
				{
					duplicateMap.Add (x.XZ, x);
				}
			});

			var message = string.Format ("Duplicate Inspect Complete, Errors: {0}", ErrorCount);
			EditorUtility.DisplayDialog ("Message", message, "Ok");
		}

		if (GUILayout.Button ("Reset Walkable", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			Array.ForEach (tiles, tile =>
			{
				tile.IsWalkable = true;
			});

			EditorUtility.DisplayDialog ("Message", "Reset Complete", "Ok");
		}

		if (GUILayout.Button ("Bake Obstacles", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			Action<AstarObstacle> SetUnPassable = (obstacle) =>
			Array.ForEach (tiles, tile =>
			{
				Bounds b = tile.GetComponent<Collider> ().bounds;
				b.SetMinMax (b.min + Vector3.up, b.max + Vector3.up);
				if (obstacle.GetComponent<Collider> ().bounds.Intersects (b))
				{
					tile.IsWalkable = false;
				}
			});
			
			Array.ForEach (FindObjectsOfType<AstarObstacle> (), SetUnPassable);

			EditorUtility.DisplayDialog ("Message", "Bake Complete", "Ok");
		}

		if (GUILayout.Button ("Normalize Pos", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			Array.ForEach (tiles, tile =>
			{
				tile.transform.position = new Vector3 (tile.X, tile.transform.position.y, tile.Z);
			});

			EditorUtility.DisplayDialog ("Message", "Normalize Complete", "Ok");
		}
	}
}
