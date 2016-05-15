using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class MenuTools : Editor
{
	[MenuItem ("RBaseTools/Go FrontEnd %#e")]
	public static void GoToFrontEnd ()
	{
		EditorApplication.isPlaying = false;
		EditorSceneManager.OpenScene ("Assets/Scenes/FrontEnd.unity", OpenSceneMode.Single);
	}

	[MenuItem ("RBaseTools/Go Singleton %#r")]
	public static void SingletonSet ()
	{
		EditorApplication.isPlaying = false;
		EditorSceneManager.OpenScene ("Assets/Scenes/Singleton.unity", OpenSceneMode.Single);
	}

	[MenuItem ("RBaseTools/Clear Logs %l")]
	public static void ClearLogs ()
	{
		Debug.ClearDeveloperConsole ();
	}

	// Suppress warning
	void Start ()
	{
	}
}