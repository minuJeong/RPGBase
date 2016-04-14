using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Hud : MonoBehaviour
{
	public void LoadLevel (string levelName)
	{
		SceneManager.LoadScene (levelName, LoadSceneMode.Single);
	}
}
