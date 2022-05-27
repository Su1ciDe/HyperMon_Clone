using UnityEngine;

public class HyperBall : MonoBehaviour
{
	public int Value = 50;

	private void OnTriggerEnter(Collider other)
	{
		if (other.isTrigger && other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out HyperMonController hyperMonController))
		{
			hyperMonController.CollectHyperBall(this);
			
			// particle effects
			gameObject.SetActive(false);
		}
	}
}