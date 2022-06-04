using TMPro;
using UnityEngine;

public class ArenaUI : MonoBehaviour
{
	[Header("Trainers")]
	public TextMeshProUGUI txtPlayerScore;
	public TextMeshProUGUI txtEnemyScore;

	[Header("Cards")]
	[SerializeField] private Card cardPrefab;
	public Transform CardPanel;

	private void Awake()
	{
		HyperMonController.OnHyperMonAdd += AddCard;
		gameObject.SetActive(false);
	}

	private void OnEnable()
	{
		Arena.OnSelectForDuel += OnCardSelected;
	}

	private void OnDisable()
	{
		Arena.OnSelectForDuel -= OnCardSelected;
	}

	private void AddCard(HyperMon addedHyperMon)
	{
		var card = Instantiate(cardPrefab, CardPanel);
		card.Setup(addedHyperMon);
	}

	private void OnCardSelected(HyperMon hyperMon)
	{
		CardPanel.gameObject.SetActive(false);
	}
}