using System.Collections;
using TMPro;
using UnityEngine;

public class HyperMon : MonoBehaviour
{
	public HyperMonSO HyperMonAttributes { get; set; }
	public TrainerType Trainer { get; set; }

	public GameObject Ui { get; private set; }

	[SerializeField] private Transform modelHolder;
	[SerializeField] private TextMeshProUGUI txtPower;

	private void Awake()
	{
		Ui = GetComponentInChildren<Canvas>(true).gameObject;
	}

	public void Setup(HyperMonSO hyperMonSO)
	{
		HyperMonAttributes = hyperMonSO;

		Instantiate(HyperMonAttributes.Model, modelHolder);
		txtPower.SetText(HyperMonAttributes.Power.ToString());
	}

	public void Attack(HyperMon target)
	{
		StartCoroutine(AttackCoroutine(target));
	}

	private IEnumerator AttackCoroutine(HyperMon target)
	{
		//TODO: animation
		
		yield return new WaitForSeconds(1);

		target.TakeDamage(HyperMonAttributes.Power);
	}

	public void TakeDamage(int damage)
	{
		if (HyperMonAttributes.Power - damage <= 0)
			Die();
	}

	private void Die()
	{
		//TODO: animation

		if (Trainer == TrainerType.Player)
			Arena.Instance.Enemy.Score++;
		else if (Trainer == TrainerType.Enemy)
			Player.Instance.Score++;
	}
}