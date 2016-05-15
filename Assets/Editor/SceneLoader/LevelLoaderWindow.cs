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
		if (GUILayout.Button ("Singleton"))
		{
			EditorSceneManager.OpenScene (SINGLETON_PATH, OpenSceneMode.Single);
		}

		if (GUILayout.Button ("FrontEnd"))
		{
			EditorSceneManager.OpenScene (FRONTEND_PATH, OpenSceneMode.Single);
		}
			
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