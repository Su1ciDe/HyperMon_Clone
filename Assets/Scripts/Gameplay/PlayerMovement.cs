using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public bool CanMove { get; set; } = true;

	[SerializeField] private float moveSpeed = 500;
	[SerializeField] private float moveSpeedMultiplier = 1;

	private void Update()
	{
		Move();
	}

	private void Move()
	{
		if (!CanMove) return;

		transform.Translate(moveSpeed * moveSpeedMultiplier * Time.deltaTime * Vector3.forward);
	}
}