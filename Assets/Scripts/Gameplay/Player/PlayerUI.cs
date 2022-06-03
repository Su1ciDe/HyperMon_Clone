using TMPro;
using DG.Tweening;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI txtHyperPoint;
	[SerializeField] private float pointAnimationDuration = .25f;

	private void OnEnable()
	{
		HyperMonController.OnHyperBallCollect += OnHyperBallCollect;
	}

	private void OnDisable()
	{
		HyperMonController.OnHyperBallCollect -= OnHyperBallCollect;
	}

	private void OnHyperBallCollect(HyperBall ball)
	{
		ChangePoint();
	}

	private void ChangePoint()
	{
		int currentPoint = int.Parse(txtHyperPoint.text);
		int nextPoint = Player.Instance.TotalHyperPoint;

		txtHyperPoint.DOComplete();
		DOTween.To(() => currentPoint, x => currentPoint = x, nextPoint, pointAnimationDuration).SetEase(Ease.OutCubic).SetTarget(txtHyperPoint)
			.OnUpdate(() => txtHyperPoint.SetText(Mathf.CeilToInt(currentPoint).ToString()));
	}
}