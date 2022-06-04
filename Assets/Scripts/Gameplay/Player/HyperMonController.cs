using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class HyperMonController : MonoBehaviour
{
	public bool CanFollow { get; set; } = true;
	public bool CanEnterGate { get; set; } = true;
	private const float gateTriggerCooldown = .5f;

	public List<HyperMon> HyperMons { get; private set; } = new List<HyperMon>();
	public int HyperMonCount => HyperMons.Count;

	[Range(1, 6)]
	public int maxHyperMonCount = 3;

	[Space]
	public HyperMon HyperMonPrefab;
	[SerializeField] private Transform hyperBallHolder;
	private GameObject hyperBall;

	[Space]
	[SerializeField] private Transform hyperMonsHolder;
	[SerializeField] private float followDamping = 1;

	private const float maxStackCount = 3;
	private const float distance = 2;
	private const float width = 9;

	private Player player => Player.Instance;

	public static event UnityAction<HyperMon> OnHyperMonAdd;
	public static event UnityAction<HyperBall> OnHyperBallCollect;

	private void Awake()
	{
		if (!hyperMonsHolder) hyperMonsHolder = GameObject.FindWithTag("HyperMonsHolder").transform; //fallback
		hyperBall = hyperBallHolder.GetChild(0).gameObject;
	}

	private void LateUpdate()
	{
		Follow();
	}

	private void Follow()
	{
		if (!CanFollow) return;
		hyperMonsHolder.position = new Vector3(Mathf.Lerp(hyperMonsHolder.position.x, transform.position.x, followDamping * Time.deltaTime), transform.position.y, transform.position.z);
	}

	private void OnEnable()
	{
		Arena.OnSelectForDuel += ThrowHyperBall;
	}

	private void OnDisable()
	{
		Arena.OnSelectForDuel -= ThrowHyperBall;
	}

	public void CollectHyperBall(HyperBall collectedHyperBall)
	{
		player.TotalHyperPoint += collectedHyperBall.Value;

		//

		OnHyperBallCollect?.Invoke(collectedHyperBall);
	}

	public void EnterGate(HyperMonSO hyperMonSO, int cost)
	{
		if (HyperMonCount >= maxHyperMonCount) return;

		StartCoroutine(GateCooldown());

		player.TotalHyperPoint -= cost;
		var hyperMon = Instantiate(HyperMonPrefab, hyperMonsHolder);
		hyperMon.Setup(hyperMonSO);
		hyperMon.Trainer = TrainerType.Player;
		HyperMons.Add(hyperMon);
		GameManager.Instance.CamTargetGroup.AddMember(hyperMon.transform, 1, 0);

		AdjustHyperMonsPositions();

		OnHyperMonAdd?.Invoke(hyperMon);
	}

	private IEnumerator GateCooldown()
	{
		CanEnterGate = false;
		yield return new WaitForSeconds(gateTriggerCooldown);
		CanEnterGate = true;
	}

	private void AdjustHyperMonsPositions()
	{
		int count = HyperMons.Count;

		for (int i = 0; i < count; i++)
		{
			float distBetween;
			if ((i < maxStackCount || count % maxStackCount == 0) && count >= maxStackCount)
				distBetween = width / (maxStackCount + 1);
			else
				distBetween = width / (count % maxStackCount + 1);
			float backward = distance * Mathf.CeilToInt((i + 1) / maxStackCount);

			HyperMons[i].transform.localPosition = new Vector3((i % maxStackCount + 1) * distBetween - width / 2f, 0, -backward);
		}
	}

	public void ThrowHyperBall(HyperMon hyperMon)
	{
		HyperMons.Remove(hyperMon);

		Sequence seq = DOTween.Sequence();
		hyperBall.SetActive(true);
		//TODO: animation
		seq.AppendInterval(.25f);
		seq.AppendCallback(() => hyperBall.transform.SetParent(null));
		seq.Append(hyperBall.transform.DOJump(Arena.Instance.PlayerHmPosition.position, 1, 1, .75f));
		seq.Join(hyperBall.transform.DORotate(720 * Vector3.right, .75f, RotateMode.FastBeyond360).SetEase(Ease.Linear));
		seq.AppendCallback(() =>
		{
			//TODO: particle effects
			hyperMon.transform.position = Arena.Instance.PlayerHmPosition.position;
			hyperMon.gameObject.SetActive(true);
			hyperMon.transform.localScale = Vector3.zero;

			hyperBall.transform.SetParent(hyperBallHolder);
			hyperBall.transform.localPosition = Vector3.zero;
			hyperBall.transform.localRotation = Quaternion.identity;
		});
		seq.Append(hyperMon.transform.DOScale(Vector3.one, .5f).SetEase(Ease.OutBounce));
		seq.AppendInterval(1);
		seq.AppendCallback(() => StartCoroutine(Arena.Instance.Fight()));
	}
}