using UnityEngine;

public class HyperBall : Collectable
{
	public int Value = 50;

	protected override void OnCollect(ICollector collector)
	{
		collector.OnCollect(this);

		//TODO: particle effects
		
		gameObject.SetActive(false);
	}
}