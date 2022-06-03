using UnityEngine;

public class LevelFailScreen : MonoBehaviour
{
	public void Retry()
	{
		LevelManager.Instance.Restart();
		SetActive(false);
	}

	public void SetActive(bool isActive)
	{
		gameObject.SetActive(isActive);
	}
}
