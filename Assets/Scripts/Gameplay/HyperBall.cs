using UnityEngine;

public class HyperBall : Collectable
{
	public int Value = 50;

	protected override void OnCollect(Player player)
	{
		player.HyperMonController.CollectHyperBall(this);

		//TODO: particle effects
		
		gameObject.SetActive(false);
	}
}