using UnityEngine;

namespace Runtime.SFX
{
	[CreateAssetMenu(fileName = "AudioConfig", menuName = "Audio/Create audio config", order = 1)]
	public class Sound : ScriptableObject
	{
		public AudioClip Clip;

		[Range(0, 1)]
		public float Volume;

		public bool IsLoop;
	}
}
