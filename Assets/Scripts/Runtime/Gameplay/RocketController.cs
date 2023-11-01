using UnityEngine;

namespace Runtime.Gameplay
{
	[RequireComponent(typeof(Rigidbody))]
	public class RocketController : MonoBehaviour
	{
		[SerializeField] private float _flySpeed;
		[SerializeField] private float _rotateSpeed;

		private Rigidbody _rigidbody;

		public bool IsRocketDead { get; set; }

		private void Awake()
		{
			Initialize();
		}

		private void FixedUpdate()
		{
			if(!IsRocketDead)
			{
				RocketFlight();
				RocketRotation();
			}
		}

		private void Initialize()
		{
			_rigidbody = GetComponent<Rigidbody>();
			IsRocketDead = false;
		}

		private void RocketFlight()
		{
			if(Input.GetKey(KeyCode.Space))
			{
				_rigidbody.AddRelativeForce(Vector3.up * _flySpeed);
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
	}
}
