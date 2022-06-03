using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "Levels", order = 3)]
public class LevelsSO : ScriptableObject
{
	public List<SceneAsset> Scenes = new List<SceneAsset>();
}