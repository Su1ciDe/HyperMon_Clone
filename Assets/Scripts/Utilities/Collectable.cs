using UnityEngine;

public abstract class Collectable : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.isTrigger && other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out Player player))
		{
			OnCollect(player);
		}
	}

	public abstract void OnCollect(Player player);
}
