using UnityEngine;

public class Player : Singleton<Player>
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

	private void Awake()
	{
		PlayerController = GetComponent<PlayerController>();
		PlayerMovement = GetComponent<PlayerMovement>();
		HyperMonController = GetComponent<HyperMonController>();
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
}