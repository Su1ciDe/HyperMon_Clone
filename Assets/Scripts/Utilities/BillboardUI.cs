using UnityEngine;

namespace VP.Nest.Utilities
{
	public class BillboardUI : MonoBehaviour
	{
		private Transform camTransform;

		private void Awake()
		{
			if (GameManager.MainCamera)
			{
				camTransform = GameManager.MainCamera.transform;
				if (TryGetComponent(out Canvas canvas) && !canvas.worldCamera)
					canvas.worldCamera = GameManager.MainCamera;
			}
			else
				Debug.LogError("Main Camera is empty!");
		}

		private void LateUpdate()
		{
			transform.LookAt(transform.position + camTransform.rotation * Vector3.forward, camTransform.rotation * Vector3.up);
		}
	}
}