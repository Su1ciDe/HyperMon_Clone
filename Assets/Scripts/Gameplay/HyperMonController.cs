using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HyperMonController : MonoBehaviour
{
	public List<HyperMon> HyperMons { get; private set; } = new List<HyperMon>();
	public int HyperMonCount => HyperMons.Count;

	[Range(1, 6)]
	public int maxHyperMonCount = 3;

	[Space]
	public HyperMon hyperMonPrefab;
	[Space]
	[SerializeField] private Transform hyperMonHolder;
	[SerializeField] private float followDamping = 1;
	private float previousPosX;
	private const float stackCountHorizontal = 3;
	private const float distance = 2;
	private const float width = 9;

	private Player player => Player.Instance;

	public static event UnityAction<HyperBall> OnHyperBallCollect;

	private void LateUpdate()
	{
		Follow();
	}

	private void Follow()
	{
		var pos = hyperMonHolder.position;
		pos = new Vector3(Mathf.Lerp(pos.x, previousPosX, followDamping * Time.deltaTime), pos.y, pos.z);
		hyperMonHolder.position = pos;
		previousPosX = transform.position.x;
	}

	public void CollectHyperBall(HyperBall hyperBall)
	{
		player.TotalHyperPoint += hyperBall.Value;

		//

		OnHyperBallCollect?.Invoke(hyperBall);
	}

	public void EnterGate(HyperMonSO hyperMonSO)
	{
		if (HyperMonCount >= maxHyperMonCount) return;

		var hyperMon = Instantiate(hyperMonPrefab, hyperMonHolder);
		hyperMon.Setup(hyperMonSO);
		HyperMons.Add(hyperMon);
		GameManager.Instance.CamTargetGroup.AddMember(hyperMon.transform, 1, 0);

		AdjustHyperMonsPositions();
	}

	private void AdjustHyperMonsPositions()
	{
		int count = HyperMons.Count;

		for (int i = 0; i < count; i++)
		{
			float distBetween;
			if ((i < stackCountHorizontal || count % stackCountHorizontal == 0) && count >= stackCountHorizontal)
				distBetween = width / (stackCountHorizontal + 1);
			else
				distBetween = width / (count % stackCountHorizontal + 1);
			float backward = distance * Mathf.CeilToInt((i + 1) / stackCountHorizontal);

			HyperMons[i].transform.localPosition = new Vector3(((i % stackCountHorizontal + 1) * distBetween) - width / 2f, 0, -backward);
		}
	}
}