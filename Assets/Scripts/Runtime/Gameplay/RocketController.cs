using UnityEngine.Events;
using UnityEngine;

namespace Runtime.Gameplay
{
	[RequireComponent(typeof(Rigidbody))]
	public class RocketController : MonoBehaviour
	{
		[SerializeField] private float _flySpeed;
		[SerializeField] private float _rotateSpeed;

		private bool _isRocketControlActive;
		private bool _isRocketFlying;
		private Rigidbody _rigidbody;

		public UnityEvent OnRocketStartedFlight;
		public UnityEvent OnRocketCompletedFlight;

		private void Awake()
		{
			Initialize();
		}

		private void FixedUpdate()
		{
			if(_isRocketControlActive)
			{
				RocketFlight();
				RocketRotation();
			}
		}

		public void Initialize()
		{
			_rigidbody = GetComponent<Rigidbody>();
			_isRocketControlActive = true;
		}

		private void RocketFlight()
		{
			if(Input.GetKey(KeyCode.Space))
			{
				_rigidbody.AddRelativeForce(Vector3.up * _flySpeed);

				if(!_isRocketFlying)
				{
					_isRocketFlying = true;
					OnRocketStartedFlight?.Invoke();
				}
			}
			else
			{
				if (_isRocketFlying)
				{
					_isRocketFlying = false;
					OnRocketCompletedFlight?.Invoke();
				}
			}
		}

		private void RocketRotation()
		{
			if (Input.GetKey(KeyCode.A))
			{
				transform.Rotate(Vector3.left * _rotateSpeed);
			}
			else if (Input.GetKey(KeyCode.D))
			{
				transform.Rotate(Vector3.right * _rotateSpeed);
			}
		}

		public void DeactivateRocketControl()
		{
			_isRocketControlActive = false;
		}
	}
}
