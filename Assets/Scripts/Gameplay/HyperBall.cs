using UnityEngine;

public class HyperBall : Collectable
{
	public int Value = 50;


	public override void OnCollect(Player player)
	{
		player.HyperMonController.CollectHyperBall(this);

		// particle effects
		gameObject.SetActive(false);
	}
}