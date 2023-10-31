using UnityEngine;
using Extencions;

namespace Runtime.SFX
{
	public class AudioManager : MonoBehaviour
	{
		[SerializeField] private AudioSource _audioSource;

		public void PlaySound(Sound sound)
		{
			StopSound();

			_audioSource.SetSound(sound);
			_audioSource.Play();
		}

		public void StopSound()
		{
			if (_audioSource.isPlaying)
			{
				_audioSource.Stop();
			}
		}
	}
}
