using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotTxtBook : ItemSlot
{
	[SerializeField] private int maxNumberPhrase = 4;

	public static ItemSlotTxtBook Instance;

	private int actualNumberPhrase = 0;

	override protected void Awake()
	{
		base.Awake();

		if (Instance != this)
			Instance = this;
	}


	override protected void OnDropObject(GameObject dragObject)
	{
		if (actualNumberPhrase >= maxNumberPhrase)
			return;

		IncreaseNumberPhrase(1);

		base.OnDropObject(dragObject);
		dragObject.transform.SetParent(transform);

		if (actualNumberPhrase >= maxNumberPhrase)
			Debug.LogWarning("Passe a scene suivante");
	}

	public void IncreaseNumberPhrase(int numberToAdd)
	{
		actualNumberPhrase += numberToAdd;
		actualNumberPhrase = Mathf.Clamp(actualNumberPhrase,0, maxNumberPhrase);
	}
}
