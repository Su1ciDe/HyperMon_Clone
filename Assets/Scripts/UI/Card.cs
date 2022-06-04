using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI txtPower;
	[SerializeField] private Image imgHyperMon;
	[SerializeField] private Image cardBG;
	[SerializeField] private Button button;

	private int index;
	private HyperMon pairedHyperMon;


	private void Awake()
	{
		button = GetComponent<Button>();
	}

	public void Setup(HyperMon hyperMon)
	{
		pairedHyperMon = hyperMon;
		txtPower.SetText(hyperMon.HyperMonAttributes.Power.ToString());
		imgHyperMon.sprite = hyperMon.HyperMonAttributes.Image;
		cardBG.color = GameManager.Instance.ColorScheme.RarityColorPairs[hyperMon.HyperMonAttributes.Rarity];
		index = Player.Instance.HyperMonController.HyperMonCount - 1;

		button.onClick.AddListener(Select);
	}

	public void Select()
	{
		Arena.OnSelectForDuel?.Invoke(pairedHyperMon);
		Destroy(gameObject, 1);
	}
}