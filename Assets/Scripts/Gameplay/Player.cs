using UnityEngine;

public class Player : Singleton<Player>
{
	public int TotalHyperPoint { get; set; }
	
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