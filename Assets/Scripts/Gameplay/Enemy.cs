using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	private int score;
	public int Score
	{
		get => score;
		set
		{
			score = value;
			UIManager.Instance.ArenaUI.txtEnemyScore.SetText(score.ToString());
		}
	}

	public AnimationController Animations { get; private set; }

	[SerializeField] private List<HyperMonSO> enemyHyperMons = new List<HyperMonSO>();
	private List<HyperMon> hyperMons = new List<HyperMon>();

	[SerializeField] private Transform hyperBallHolder;
	private GameObject hyperBall;

	private void Awake()
	{
		hyperBall = hyperBallHolder.GetChild(0).gameObject;
		Animations = GetComponentInChildren<AnimationController>();
	}

	private void Start()
	{
		foreach (var hyperMon in enemyHyperMons)
		{
			var newHyperMon = Instantiate(Player.Instance.HyperMonController.HyperMonPrefab, transform);
			newHyperMon.Setup(hyperMon);
			newHyperMon.Trainer = TrainerType.Enemy;
			newHyperMon.gameObject.SetActive(false);
			hyperMons.Add(newHyperMon);
		}
	}

	public YieldInstruction ThrowHyperBall()
	{
		int randomBallIndex = Random.Range(0, hyperMons.Count - 1);
		var hyperMon = Arena.Instance.DuelingEnemyHyperMon = hyperMons[randomBallIndex];
		hyperMons.RemoveAt(randomBallIndex);

		Sequence seq = DOTween.Sequence();
		hyperBall.SetActive(true);

		Animations.SetTrigger(AnimationType.Throw);
		seq.AppendInterval(.25f);
		seq.AppendCallback(() => hyperBall.transform.SetParent(null));
		seq.Append(hyperBall.transform.DOJump(Arena.Instance.EnemyHmPosition.position, 4, 1, .75f));
		seq.Join(hyperBall.transform.DORotate(720 * Vector3.right, .75f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
		seq.AppendCallback(() =>
		{
			//TODO: particle effects
			hyperMon.transform.position = Arena.Instance.EnemyHmPosition.position;
			hyperMon.gameObject.SetActive(true);
			hyperMon.transform.localScale = Vector3.zero;

			hyperBall.transform.SetParent(hyperBallHolder);
			hyperBall.transform.localPosition = Vector3.zero;
			hyperBall.transform.localRotation = Quaternion.identity;
			hyperBall.SetActive(false);
		});
		seq.Append(hyperMon.transform.DOScale(3 * Vector3.one, .5f).SetEase(Ease.OutBounce));
		seq.AppendCallback(() => hyperMon.Ui.SetActive(true));

		return seq.WaitForCompletion();
	}
}