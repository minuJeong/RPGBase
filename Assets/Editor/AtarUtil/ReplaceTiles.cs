using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;

public class ReplaceTiles : EditorWindow
{
	GameObject NewPrefab;

	void RefreshSelection ()
	{
		
	}

	void OnGUI ()
	{
		Scene currentScene = SceneManager.GetActiveScene ();

		Selection.selectionChanged += RefreshSelection;
		GUILayout.Label (String.Format ("{0} objects selected", Selection.gameObjects.Length));

		NewPrefab = (GameObject)EditorGUILayout.ObjectField ("New Prefab", NewPrefab, typeof(GameObject), false);

		GUI.enabled = NewPrefab != null;
		if (GUILayout.Button ("Replace"))
		{
			Array.ForEach (Selection.gameObjects, (GameObject go) =>
			{
				// Ignore prefabs selection
				if (!go.scene.isLoaded)
				{
					return;
				}

				GameObject newObject = PrefabUtility.ConnectGameObjectToPrefab (Instantiate (NewPrefab), NewPrefab);

				newObject.transform.SetParent (go.transform.parent);
				newObject.transform.position = go.transform.position;
				newObject.transform.localScale = go.transform.localScale;
				newObject.transform.rotation = go.transform.rotation;

				EditorUtility.SetDirty (go);
				EditorUtility.SetDirty (newObject);

				DestroyImmediate (go);
			});

			EditorSceneManager.MarkSceneDirty (currentScene);
		}

	}
}
