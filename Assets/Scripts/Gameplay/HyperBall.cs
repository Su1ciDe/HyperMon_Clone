using UnityEngine;

public class HyperBall : Collectable
{
	public int Value = 50;

	protected override void OnCollect(ICollector collector)
	{
		collector.OnCollect(this);

		ParticleSystem particle = Value > 0
			? ObjectPooler.Instance.Spawn("HyperBallGreen", transform.position).GetComponent<ParticleSystem>()
			: ObjectPooler.Instance.Spawn("HyperBallBlack", transform.position).GetComponent<ParticleSystem>();
		particle.Play();

		gameObject.SetActive(false);
	}
}