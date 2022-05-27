using UnityEngine;
using UnityEngine.Events;

public class HyperMonController : MonoBehaviour
{
	public static event UnityAction<HyperBall> OnHyperBallCollect;

	public void CollectHyperBall(HyperBall hyperBall)
	{
		//
		
		OnHyperBallCollect?.Invoke(hyperBall);
	}
}
