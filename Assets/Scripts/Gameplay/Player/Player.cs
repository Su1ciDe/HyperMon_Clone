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
}