using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HyperMonGate : Gate
{
	[SerializeField] private HyperMonSO hyperMonAttributes;
	[SerializeField] private int cost;

	[Space]
	[SerializeField] private TextMeshProUGUI txtName;
	[SerializeField] private TextMeshProUGUI txtPower;
	[SerializeField] private TextMeshProUGUI txtRarity;
	[SerializeField] private TextMeshProUGUI txtCost;
	[SerializeField] private Image imgHyperMon;
	[SerializeField] private Image imgBg;

	protected override void OnEnter(Player player)
	{
		if (player.TotalHyperPoint >= cost)
		{
			player.HyperMonController.EnterGate(hyperMonAttributes);
		}
		else
			player.PlayerMovement.JumpBack();

		gameObject.SetActive(false);
	}
	
#if UNITY_EDITOR
	private void OnValidate()
	{
		if (!hyperMonAttributes) return;

		txtCost.SetText(cost.ToString());
		txtName.SetText(hyperMonAttributes.Name);
		txtPower.SetText(hyperMonAttributes.Power.ToString());
		txtRarity.SetText(hyperMonAttributes.Rarity.ToString());

		imgHyperMon.sprite = hyperMonAttributes.Image;
		if (GameManager.Instance && GameManager.Instance.ColorScheme.RarityColorPairs.Count > 0)
			imgBg.color = GameManager.Instance.ColorScheme.RarityColorPairs[hyperMonAttributes.Rarity];
	}
#endif
}