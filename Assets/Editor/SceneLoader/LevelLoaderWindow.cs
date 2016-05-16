using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using System;
using System.IO;
using System.Collections.Generic;

public class LevelLoaderWindow : EditorWindow
{
	const string SINGLETON_PATH = "Assets/Scenes/Singleton.unity";
	const string FRONTEND_PATH = "Assets/Scenes/FrontEnd.unity";
	const string SCENE_PATH = "Assets/Scenes/Levels";

	[MenuItem ("RBaseTools/EditorExtension/SceneLoader %#l")]
	public static void OpenLoader ()
	{
		EditorWindow.GetWindow<LevelLoaderWindow> ();
	}

	void OnGUI ()
	{
		// Style Defs
		GUIStyle labelStyle_Title_1 = new GUIStyle ();
		labelStyle_Title_1.fontSize = 14;
		labelStyle_Title_1.margin = new RectOffset (10, 0, 15, 3);

		GUIStyle labelStyle_Title_2 = new GUIStyle ();
		labelStyle_Title_2.fontSize = 12;
		labelStyle_Title_2.margin = new RectOffset (15, 0, 5, 2);


		// Title
		GUILayout.Label ("Level Loader", labelStyle_Title_1);


		// System Levels
		GUILayout.Label ("System Levels", labelStyle_Title_2);
		if (GUILayout.Button ("Singleton"))
		{
			EditorSceneManager.OpenScene (SINGLETON_PATH, OpenSceneMode.Single);
		}

		if (GUILayout.Button ("FrontEnd"))
		{
			EditorSceneManager.OpenScene (FRONTEND_PATH, OpenSceneMode.Single);
		}


		// Normal Levels
		GUILayout.Label ("Normal Levels", labelStyle_Title_2);
		var scenes = new List<string> (Directory.GetFiles (SCENE_PATH, "*.unity"));
		scenes.ForEach (path =>
		{
			var sceneName = Path.GetFileName (path).Replace (".unity", "");
			if (GUILayout.Button (sceneName))
			{
				ConfirmAddedToBuildSettings (path);

				EditorSceneManager.OpenScene (path, OpenSceneMode.Single);
			}
		});
	}

	/// <summary>
	/// if scene path is not added to build settings, add it
	/// </summary>
	/// <param name="path">Path.</param>
	void ConfirmAddedToBuildSettings (string path)
	{
		if (Array.Find (EditorBuildSettings.scenes, x => x.path == path) == null)
		{
			var newScenes = new EditorBuildSettingsScene [EditorBuildSettings.scenes.Length + 1];
			Array.Copy (EditorBuildSettings.scenes, newScenes, EditorBuildSettings.scenes.Length);
			newScenes [newScenes.Length - 1] = new EditorBuildSettingsScene (path, true);
			EditorBuildSettings.scenes = newScenes;
		}
	}
}