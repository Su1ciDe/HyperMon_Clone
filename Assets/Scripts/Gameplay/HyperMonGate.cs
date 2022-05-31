using UnityEngine;

public class HyperMonGate : Gate
{
	[SerializeField] private HyperMonSO hyperMonAttributes;
	[SerializeField] private int cost;
	
	protected override void OnEnter(Player player)
	{
		if (player.TotalHyperPoint >= cost)
			player.HyperMonController.EnterGate(hyperMonAttributes);
		else
			player.PlayerMovement.JumpBack();
		
		gameObject.SetActive(false);
	}
}
