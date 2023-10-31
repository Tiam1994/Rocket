using UnityEngine.SceneManagement;
using UnityEngine;

namespace Runtime.Scenes
{
	public class SceneLoader : MonoBehaviour
	{
		public void LoadSceneByIndex(int level)
		{
			SceneManager.LoadScene(level);
		}

		public void LoadNextScene()
		{
			int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

			SceneManager.LoadScene(currentSceneIndex + 1);
		}
	}
}
