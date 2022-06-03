using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI txtPower;
	[SerializeField] private Image imgHyperMon;
	[SerializeField] private Image cardBG;

	private int index;

	private Button button;

	private void Awake()
	{
		button = GetComponent<Button>();
	}

	public void Setup(HyperMon hyperMon)
	{
		txtPower.SetText(hyperMon.HyperMonAttributes.Power.ToString());
		imgHyperMon.sprite = hyperMon.HyperMonAttributes.Image;
		cardBG.color = GameManager.Instance.ColorScheme.RarityColorPairs[hyperMon.HyperMonAttributes.Rarity];
		index = Player.Instance.HyperMonController.HyperMonCount - 1;

		button.onClick.AddListener(Select);
	}

	public void Select()
	{
		Arena.OnSelectForDuel?.Invoke(Player.Instance.HyperMonController.HyperMons[index]);
	}
}