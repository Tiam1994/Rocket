using Runtime.Gameplay.Constants;
using UnityEngine.Events;
using UnityEngine;

namespace Runtime.Gameplay
{
	[RequireComponent (typeof(Collider))]
	public class RocketInteraction : MonoBehaviour
	{
		private bool _isRocketInteractionActive = true;

		public UnityEvent OnInteractionWithObstacle;
		public UnityEvent OnInteractionWithLandingPad;

		private void OnCollisionEnter(Collision collision)
		{
			if(_isRocketInteractionActive)
			{
				CollisionRocket(collision.gameObject.tag);
			}
		}

		private void CollisionRocket(string collisionObject)
		{
			switch (collisionObject)
			{
				case TagConstants.OBSTACLE_TAG:
					OnInteractionWithObstacle?.Invoke();
					break;
				case TagConstants.LANDING_PAD_TAG:
					OnInteractionWithLandingPad?.Invoke();
					break;
			}
		}

		public void DeactivateRocketInteraction()
		{
			_isRocketInteractionActive = false;
		}
	}
}
