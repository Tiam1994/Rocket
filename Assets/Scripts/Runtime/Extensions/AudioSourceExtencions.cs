using Runtime.SFX;
using UnityEngine;

namespace Extencions
{
	public static class AudioSourceExtencions
	{
		public static void SetSound(this AudioSource audioSource, Sound sound)
		{
			audioSource.clip = sound.Clip;
			audioSource.volume = sound.Volume;
			audioSource.loop = sound.IsLoop;
		}
	}
}
