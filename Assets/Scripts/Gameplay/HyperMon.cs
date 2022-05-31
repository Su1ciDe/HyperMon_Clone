using TMPro;
using UnityEngine;

public class HyperMon : MonoBehaviour
{
	public HyperMonSO HyperMonAttributes { get; set; }

	[SerializeField] private Transform modelHolder;
	[SerializeField] private TextMeshProUGUI txtPower;

	public void Setup(HyperMonSO hyperMonSO)
	{
		HyperMonAttributes = hyperMonSO;

		var go = Instantiate(HyperMonAttributes.Model, modelHolder);
		txtPower.SetText(HyperMonAttributes.Power.ToString());
	}
}
