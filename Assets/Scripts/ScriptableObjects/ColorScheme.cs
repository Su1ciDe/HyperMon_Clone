using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ColorScheme", menuName = "ColorScheme", order = 1)]
public class ColorScheme : ScriptableObject
{
	[System.Serializable]
	public struct RarityColor
	{
		public RarityType Rarity;
		public Color Color;
	}

	[SerializeField] private List<RarityColor> rarityColors = new List<RarityColor>();

	public Dictionary<RarityType, Color> RarityColorPairs = new Dictionary<RarityType, Color>();

	private void OnEnable()
	{
		foreach (RarityColor rarityColor in rarityColors)
			RarityColorPairs.Add(rarityColor.Rarity, rarityColor.Color);
	}
}