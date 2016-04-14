using UnityEditor;
using UnityEditor.SceneManagement;

public class MenuTools : Editor
{
	[MenuItem ("RBaseTools/Play %#e")]
	public static void Start ()
	{
		EditorSceneManager.OpenScene ("Assets/Scenes/FrontEnd.unity", OpenSceneMode.Single);
		EditorApplication.isPlaying = true;
	}
}