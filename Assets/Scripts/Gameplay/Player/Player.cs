using UnityEngine;

public class Player : Singleton<Player>, ICollector
{
	public int TotalHyperPoint { get; set; }
	private int score;
	public int Score
	{
		get => score;
		set
		{
			score = value;
			UIManager.Instance.ArenaUI.txtPlayerScore.SetText(score.ToString());
		}
	}

	public PlayerMovement PlayerMovement { get; private set; }
	public PlayerController PlayerController { get; private set; }
	public HyperMonController HyperMonController { get; private set; }
	public PlayerUI PlayerUI { get; private set; }
	public AnimationController Animations { get; private set; }

	private void Awake()
	{
		PlayerController = GetComponent<PlayerController>();
		PlayerMovement = GetComponent<PlayerMovement>();
		HyperMonController = GetComponent<HyperMonController>();
		PlayerUI = GetComponentInChildren<PlayerUI>();
		Animations = GetComponentInChildren<AnimationController>();
	}

	private void OnEnable()
	{
		LevelManager.OnLevelStart += OnLevelStarted;
		LevelManager.OnLevelSuccess += OnLevelSucceed;
		LevelManager.OnLevelFail += OnLevelFailed;
	}

	private void OnDisable()
	{
		LevelManager.OnLevelStart -= OnLevelStarted;
		LevelManager.OnLevelSuccess -= OnLevelSucceed;
		LevelManager.OnLevelFail -= OnLevelFailed;
	}

	private void OnLevelStarted()
	{
		PlayerController.CanControl = true;
		PlayerMovement.CanMove = true;

		Animations.SetBool(AnimationType.Running, true);
	}

	private void OnLevelSucceed()
	{
		PlayerController.CanControl = false;
		PlayerMovement.CanMove = false;
	}

	private void OnLevelFailed()
	{
		PlayerController.CanControl = false;
		PlayerMovement.CanMove = false;
	}

	public void OnCollect(HyperBall hyperBall)
	{
		HyperMonController.CollectHyperBall(hyperBall);
	}
}