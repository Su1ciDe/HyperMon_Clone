using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI txtLevel;
	[SerializeField] private string levelPrefix = "Level ";

	private void Start()
	{
		ChangeLevelText(LevelManager.CurrentLevel);
	}

	public void ChangeLevelText(int levelNo)
	{
		txtLevel.SetText(levelPrefix + levelNo);
	}
}
