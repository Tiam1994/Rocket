using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runtime.UI.Animations
{
	public class UIAnimator : MonoBehaviour
	{
		[SerializeField] private List<Transform> _animatedElements;
		[SerializeField] private float _scaleFactor;
		[SerializeField] private float _animationDuration;

		private void Start()
		{
			PlayUIAnimation();
		}

		public void PlayUIAnimation()
		{
			foreach (Transform element in _animatedElements)
			{
				element.DOScale(_scaleFactor, _animationDuration).SetLoops(-1, LoopType.Yoyo);
			}
		}
	}
}
