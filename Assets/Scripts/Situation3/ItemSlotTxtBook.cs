using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotTxtBook : ItemSlot
{
	[SerializeField] private int maxNumberPhrase = 4;

	private int actualNumberPhrase = 0;

	override protected void OnDropObject(GameObject dragObject)
	{
		if (actualNumberPhrase >= maxNumberPhrase)
			return;

		actualNumberPhrase++;

		base.OnDropObject(dragObject);
		dragObject.transform.SetParent(transform);

		if (actualNumberPhrase >= maxNumberPhrase)
			Debug.Log("Passe a scene suivante");
	}
}
