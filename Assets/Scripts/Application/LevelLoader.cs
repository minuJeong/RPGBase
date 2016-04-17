using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public sealed class LevelLoader : MonoBehaviour
{
	[SerializeField]
	protected string[] _SceneNames;

	private const string SCENE_ROOT_PATH = "Levels";

	public Button _BTNLoadLevelPrefab;

	void Start ()
	{
		foreach (var o in Resources.LoadAll ("SCENE_ROOT_PATH"))
		{
			Debug.Log (o);
		}

		foreach (var sceneName in _SceneNames)
		{
			Button btn = Instantiate (_BTNLoadLevelPrefab);
			btn.transform.SetParent (transform);

			Text txt = btn.GetComponentInChildren<Text> ();
			txt.text = sceneName;
			btn.onClick.AddListener (delegate
			{
				LoadLevel (txt.text);
			});
		}
	}

	void LoadLevel (string sceneName)
	{
		Game.Instance.GetManager<LevelManager> ().LoadLevel (new MoveToEventData (sceneName, ""));
	}
}
