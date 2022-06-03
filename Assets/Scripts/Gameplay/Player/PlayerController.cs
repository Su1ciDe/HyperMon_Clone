using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public bool CanControl { get; set; }

	[SerializeField] private float dragMultiplier = 1;
	[Space]
	[SerializeField] private float leftLimit;
	[SerializeField] private float rightLimit;

	private Vector3 playerPos;
	private float previousPosX;

	private void Update()
	{
		Inputs();
	}

	private void Inputs()
	{
		if (!CanControl) return;

		if (Input.GetMouseButtonDown(0))
		{
			previousPosX = Input.mousePosition.x;
		}

		if (Input.GetMouseButton(0))
		{
			playerPos = transform.position;
			playerPos.x = Mathf.Clamp(playerPos.x + dragMultiplier * Time.deltaTime * (Input.mousePosition.x - previousPosX), leftLimit, rightLimit);
			transform.position = playerPos;

			previousPosX = Input.mousePosition.x;
		}
	}
}