using UnityEngine;

public abstract class Gate : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		if (other.isTrigger && other.attachedRigidbody && other.attachedRigidbody.TryGetComponent(out Player player))
		{
			OnEnter(player);
		}
	}

	protected abstract void OnEnter(Player player);
}
