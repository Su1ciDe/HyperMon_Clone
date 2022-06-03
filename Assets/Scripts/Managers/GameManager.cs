using Cinemachine;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	private static Camera mainCamera;
	public static Camera MainCamera
	{
		get
		{
			if (!mainCamera) mainCamera = Camera.main;
			return mainCamera;
		}
	}

	public ColorScheme ColorScheme;

	[Space]
	public CinemachineTargetGroup CamTargetGroup;

	public void Finish()
	{
		if (Player.Instance.Score >= Arena.Instance.Enemy.Score)
			LevelManager.Instance.GameSuccess();
		else
			LevelManager.Instance.GameFail();
	}
}