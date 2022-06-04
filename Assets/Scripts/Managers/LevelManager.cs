using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
	public LevelsSO LevelSO;

	public static int CurrentLevel
	{
		get => PlayerPrefs.GetInt("CurrentLevel", 1);
		set
		{
			PlayerPrefs.SetInt("CurrentLevel", value);
			UIManager.Instance.LevelUI.ChangeLevelText(value);
		}
	}
	public int CurrentLevelIndex => CurrentLevel % LevelSO.Scenes.Count;

	public static event UnityAction OnLevelStart;
	public static event UnityAction OnLevelSuccess;
	public static event UnityAction OnLevelFail;

	public void StartLevel()
	{
		OnLevelStart?.Invoke();
	}

	public void GameSuccess()
	{
		CurrentLevel++;
		OnLevelSuccess?.Invoke();
	}

	public void GameFail()
	{
		OnLevelFail?.Invoke();
	}

	public void Restart()
	{
		LoadLevel();
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(LevelSO.Scenes[CurrentLevelIndex].name);
	}
}
