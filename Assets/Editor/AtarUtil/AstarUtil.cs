using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
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
		Scene currentScene = SceneManager.GetActiveScene ();

		const float BUTTON_WIDTH = 220;
		const float BUTTON_HEIGHT = 32;

		var tiles = FindObjectsOfType<AstarTile> ();

		if (GUILayout.Button ("Rename Tiles", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			Array.ForEach (tiles, tile =>
			{
				tile.gameObject.name = "Tile_" + tile.XZ;
				EditorUtility.SetDirty (tile);
			});

			EditorSceneManager.MarkSceneDirty (currentScene);
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

			EditorSceneManager.MarkSceneDirty (currentScene);
			var message = string.Format ("Duplicate Inspect Complete, Errors: {0}", ErrorCount);
			EditorUtility.DisplayDialog ("Message", message, "Ok");
		}

		if (GUILayout.Button ("Reset Walkable", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			Array.ForEach (tiles, tile =>
			{
				tile.IsWalkable = true;
				EditorUtility.SetDirty (tile);
			});

			EditorSceneManager.MarkSceneDirty (currentScene);
			EditorUtility.DisplayDialog ("Message", "Reset Complete", "Ok");
		}

		if (GUILayout.Button ("Bake Obstacles", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			Action<AstarObstacle> SetUnPassable = (obstacle) =>
			Array.ForEach (tiles, tile =>
			{
				Bounds b_obs = obstacle.GetComponent<Collider> ().bounds;
				Bounds b_tile = tile.GetComponent<Collider> ().bounds;
				Vector3 tileMin = b_tile.min;
				Vector3 tileMax = b_tile.max;
				float tileY = tile.transform.position.y;
				
				tileMin.y = tileY;
				tileMax.y = tileY;
				Vector3[] corners = new Vector3[] {
					tileMin,
					new Vector3 (tileMin.x, tileY, tileMax.z),
					new Vector3 (tileMax.x, tileY, tileMin.z),
					tileMax,
					tile.transform.position
				};
				
				Array.ForEach (corners, corner =>
				{
					Ray tileRay = new Ray (corner, Vector3.up);
					if (b_obs.IntersectRay (tileRay))
					{
						tile.IsWalkable = false;
					}
				});
				
				EditorUtility.SetDirty (tile);
			});
			
			Array.ForEach (FindObjectsOfType<AstarObstacle> (), SetUnPassable);

			EditorSceneManager.MarkSceneDirty (currentScene);
			EditorUtility.DisplayDialog ("Message", "Bake Complete", "Ok");
		}

		if (GUILayout.Button ("Normalize Pos", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			Array.ForEach (tiles, tile =>
			{
				tile.transform.position = new Vector3 (tile.X, tile.transform.position.y, tile.Z);
				EditorUtility.SetDirty (tile);
			});

			EditorSceneManager.MarkSceneDirty (currentScene);
			EditorUtility.DisplayDialog ("Message", "Normalize Complete", "Ok");
		}

		GUILayout.Space (10);

		if (GUILayout.Button ("Replace Selected Tiles", GUILayout.Width (BUTTON_WIDTH), GUILayout.Height (BUTTON_HEIGHT)))
		{
			ScriptableObject.CreateInstance<ReplaceTiles> ().Show ();
			EditorSceneManager.MarkSceneDirty (currentScene);
		}
	}
}
