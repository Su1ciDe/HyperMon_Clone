using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.isTrigger && other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out ICollector collector))
		{
			OnCollect(collector);
		}
	}

	protected abstract void OnCollect(ICollector collector);
}
