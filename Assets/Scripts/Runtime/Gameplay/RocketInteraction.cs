using Runtime.Gameplay.Constants;
using UnityEngine.Events;
using UnityEngine;

namespace Runtime.Gameplay
{
	[RequireComponent (typeof(Collider))]
	public class RocketInteraction : MonoBehaviour
	{
		public UnityEvent OnRocketCollision;
		public UnityEvent OnInteractionWithLandingPad;

		private void OnCollisionEnter(Collision collision)
		{
			CollisionRocket(collision.gameObject.tag);
		}

		private void CollisionRocket(string collisionObject)
		{
			switch (collisionObject)
			{
				case TagConstants.OBSTACLE_TAG:
					OnRocketCollision?.Invoke();
					break;
				case TagConstants.LANDING_PAD_TAG:
					OnInteractionWithLandingPad?.Invoke();
					break;
			}
		}
	}
}
