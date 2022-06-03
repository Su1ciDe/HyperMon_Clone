using TMPro;
using UnityEngine;

public class ArenaUI : MonoBehaviour
{
	public GameObject CardPanel;
	
	[Header("Trainers")]
	public TextMeshProUGUI txtPlayerScore;
	public TextMeshProUGUI txtEnemyScore;
		
	[Header("Cards")]
	[SerializeField] private Card cardPrefab;
	[SerializeField] private Transform cardsPanel;

	
	private void OnEnable()
	{
		HyperMonController.OnHyperMonAdd += AddCard;
		Arena.OnSelectForDuel += OnCardSelected;
	}

	private void OnDisable()
	{
		HyperMonController.OnHyperMonAdd -= AddCard;
		Arena.OnSelectForDuel -= OnCardSelected;
	}

	public void AddCard(HyperMon addedHyperMon)
	{
		var card = Instantiate(cardPrefab, cardsPanel);
		card.Setup(addedHyperMon);
	}

	private void OnCardSelected(HyperMon hyperMon)
	{
		CardPanel.SetActive(false);
	}
}