using UnityEngine.Events;
using UnityEngine;

namespace Runtime.Gameplay
{
	[RequireComponent(typeof(RocketController), typeof(RocketInteraction))]
	public class Rocket : MonoBehaviour
	{
		[SerializeField] private RocketController _rocketController;
		[SerializeField] private RocketInteraction _rocketInteraction;

		public UnityEvent OnRocketCrashed;

		public void RocketCrash()
		{
			OnRocketCrashed?.Invoke();

			_rocketController.DeactivateRocketControl();
			_rocketInteraction.DeactivateRocketInteraction();
		}
	}
}
