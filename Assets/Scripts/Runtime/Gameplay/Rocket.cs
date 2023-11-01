using UnityEngine;

namespace Runtime.Gameplay
{
	[RequireComponent(typeof(RocketController), typeof(RocketInteraction))]
	public class Rocket : MonoBehaviour
	{
		[SerializeField] private RocketController _rocketController;
		[SerializeField] private RocketInteraction _rocketInteraction;

		public void RocketCrash()
		{
			_rocketController.DeactivateRocketControl();
			_rocketInteraction.DeactivateRocketInteraction();
		}
	}
}
