using UnityEngine;

namespace Runtime.Gameplay
{
	public class Rocket : MonoBehaviour
	{
		[SerializeField] private RocketController _rocketController;

		public void RocketCrash()
		{
			_rocketController.IsRocketDead = true;
		}
	}
}
