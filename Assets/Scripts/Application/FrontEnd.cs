using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;


public class FrontEnd : MonoBehaviour
{
	void Start ()
	{
		Game game = GameObject.FindObjectOfType<Game> ();

		if (game == null)
		{
			SceneManager.LoadScene ("Singleton", LoadSceneMode.Additive);

			DontDestroyOnLoad (gameObject);
		}
	}
}
