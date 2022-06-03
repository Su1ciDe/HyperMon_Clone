using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public bool CanMove { get; set; }

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

	public void JumpBack()
	{
		CanMove = false;
		// jump animation

		transform.DOJump(transform.position - 10 * Vector3.forward, 1, 1, .5f).OnComplete(() =>
		{
			CanMove = true;
			// running animaiton
		});
	}
}