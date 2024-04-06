using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotBookFullScreen : ItemSlot
{
	[SerializeField] private Transform childToAdd = default;

	override protected void OnDropObject(GameObject dragObject)
	{
		if (dragObject.GetComponent<Dragdrop>().bookFullScreen != childToAdd)
			return;

		dragObject.transform.SetParent(childToAdd);
		base.OnDropObject(dragObject);
		ItemSlotTxtBook.Instance.IncreaseNumberPhrase(-1);
	}
}
