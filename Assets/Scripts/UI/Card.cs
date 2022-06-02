using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI txtPower;
	[SerializeField] private Image imgHyperMon;
	[SerializeField] private Image cardBG;

	public void Setup(HyperMon hyperMon)
	{
		txtPower.SetText(hyperMon.HyperMonAttributes.Power.ToString());
		imgHyperMon.sprite = hyperMon.HyperMonAttributes.Image;
		cardBG.color = GameManager.Instance.ColorScheme.RarityColorPairs[hyperMon.HyperMonAttributes.Rarity];
		
		//TODO: buttons stuff
	}
}