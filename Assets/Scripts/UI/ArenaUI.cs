using TMPro;
using UnityEngine;

public class ArenaUI : MonoBehaviour
{
	[Header("Trainers")]
	[SerializeField] private TextMeshProUGUI txtPlayerScore;
	[SerializeField] private TextMeshProUGUI txtEnemyScore;
		
	[Header("Cards")]
	[SerializeField] private Card cardPrefab;
	[SerializeField] private Transform cardsPanel;

	private void OnEnable()
	{
		HyperMonController.OnHyperMonAdd += AddCard;
	}

	private void OnDisable()
	{
		HyperMonController.OnHyperMonAdd -= AddCard;
	}

	public void AddCard(HyperMon addedHyperMon)
	{
		var card = Instantiate(cardPrefab, cardsPanel);
		card.Setup(addedHyperMon);
	}
}