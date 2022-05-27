using UnityEngine;

public class Player : Singleton<Player>
{
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