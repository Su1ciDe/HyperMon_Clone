using UnityEngine;

[CreateAssetMenu(fileName = "HyperMon", menuName = "HyperMon", order = 0)]
public class HyperMonSO : ScriptableObject
{
	public string Name;
	public int Power;

	[Space]
	public RarityType Rarity;
	
	[Space]
	public GameObject Model;
	public Sprite Image;
}