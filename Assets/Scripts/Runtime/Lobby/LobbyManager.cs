using UnityEngine.Events;
using Runtime.SFX;
using UnityEngine;

namespace Runtime.Lobby
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
