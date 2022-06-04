using System.Collections;
using Cinemachine;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class Arena : Singleton<Arena>
{
	public HyperMon DuelingPlayerHyperMon { get; set; }
	public HyperMon DuelingEnemyHyperMon { get; set; }

	public Enemy Enemy { get; private set; }

	[SerializeField] private Transform playerPosition;
	public Transform PlayerHmPosition;
	public Transform EnemyHmPosition;

	private CinemachineVirtualCamera vcam_Arena;

	public static UnityAction<HyperMon> OnSelectForDuel;

	private void Awake()
	{
		Enemy = GetComponentInChildren<Enemy>();
		vcam_Arena = GetComponentInChildren<CinemachineVirtualCamera>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.isTrigger && other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out Player player))
		{
			player.PlayerController.CanControl = false;
			player.PlayerMovement.CanMove = false;
			player.HyperMonController.CanFollow = false;
			
			vcam_Arena.gameObject.SetActive(true);

			player.transform.DOMove(playerPosition.position, 1f).SetEase(Ease.Linear).OnComplete(() => StartCoroutine(Duel()));
		}
	}

	private IEnumerator Duel()
	{
		UIManager.Instance.ArenaUI.gameObject.SetActive(true);
		yield return new WaitForSeconds(.5f);

		yield return Enemy.ThrowHyperBall();

		UIManager.Instance.ArenaUI.CardPanel.gameObject.SetActive(true);
	}

	public IEnumerator Fight()
	{
		yield return new WaitForSeconds(.5f);

		DuelingPlayerHyperMon.Attack(DuelingEnemyHyperMon);
		DuelingEnemyHyperMon.Attack(DuelingPlayerHyperMon);

		yield return new WaitForSeconds(2);
		
		DuelingPlayerHyperMon.gameObject.SetActive(false);
		DuelingEnemyHyperMon.gameObject.SetActive(false);

		if (Player.Instance.HyperMonController.HyperMonCount > 0)
			StartCoroutine(Duel());
		else
			GameManager.Instance.Finish();
	}
}