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
		int currentPoint = int.Parse(txtHyperPoint.text);
		int nextPoint = Player.Instance.TotalHyperPoint;

		DOTween.Complete("pointUpdate");
		DOTween.To(() => currentPoint, x => currentPoint = x, nextPoint, pointAnimationDuration).SetEase(Ease.OutCubic).SetId("pointUpdate")
			.OnUpdate(() => txtHyperPoint.SetText(Mathf.CeilToInt(currentPoint).ToString()));
	}
}