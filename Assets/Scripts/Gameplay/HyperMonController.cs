using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HyperMonController : MonoBehaviour
{
	public List<HyperMon> HyperMons { get; set; }= new List<HyperMon>();
	public int HyperMonCount => HyperMons.Count;

	[Range(1,6)]
	[SerializeField] private int maxHyperMonCount = 3;

	[Space]
	public HyperMon hyperMonPrefab;
	[SerializeField] private Transform hyperMonHolder;

	private Player player => Player.Instance;
	public static event UnityAction<HyperBall> OnHyperBallCollect;

	public void CollectHyperBall(HyperBall hyperBall)
	{
		player.TotalHyperPoint += hyperBall.Value;
		
		//
		
		OnHyperBallCollect?.Invoke(hyperBall);
	}

	public void EnterGate(HyperMonSO hyperMonSO)
	{
		var hyperMon = Instantiate(hyperMonPrefab, hyperMonHolder);
		hyperMon.Setup(hyperMonSO);
	}

	public void AddHyperMon()
	{
		
	}
}
