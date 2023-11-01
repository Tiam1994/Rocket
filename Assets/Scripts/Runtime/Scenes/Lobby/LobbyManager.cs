using UnityEngine.Events;
using UnityEngine;

namespace Runtime.Scenes.Lobby
{
	public class LobbyManager : MonoBehaviour
	{
		public UnityEvent StartScene;

		private void Start()
		{
			StartScene?.Invoke();
		}
	}
}
