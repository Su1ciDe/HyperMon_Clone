using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	public LevelUI LevelUI => levelUI ? levelUI : levelUI = GetComponentInChildren<LevelUI>(true);
	private LevelUI levelUI;

	public ArenaUI ArenaUI => arenaUI ? arenaUI : arenaUI = GetComponentInChildren<ArenaUI>(true);
	private ArenaUI arenaUI;
}