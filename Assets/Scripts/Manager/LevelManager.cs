using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : Manager
{
	protected override void OnInit ()
	{
		// Do nothing
	}

	public void LoadLevel (MoveToEventData eventData)
	{
		if (string.IsNullOrEmpty (eventData._SceneName))
		{
			return;
		}

		if (SceneManager.GetActiveScene ().name == eventData._SceneName)
		{
			return;
		}

		AsyncOperation op = SceneManager.LoadSceneAsync (eventData._SceneName, LoadSceneMode.Single);

		StartCoroutine (WaitLoadAndStartLevel (op));
	}

	IEnumerator WaitLoadAndStartLevel (AsyncOperation operation)
	{
		yield return operation;

		Game.Instance.DispatchEvent (EventName.START_LEVEL, new LevelStartEventData ());
	}
}
