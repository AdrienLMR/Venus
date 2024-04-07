using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSlotBookFullScreen : ItemSlot
{
	[SerializeField] private Transform childToAdd = default;
	[SerializeField] private List<Transform> allContainerText = default;

	override protected void OnDropObject(GameObject dragObject)
	{
		if (dragObject.GetComponent<Dragdrop>().bookFullScreen != childToAdd)
			return;

		foreach (var containerTxt in allContainerText)
		{
			if (containerTxt.childCount == 0)
				dragObject.transform.SetParent(containerTxt);
		}

		base.OnDropObject(dragObject);
		ItemSlotTxtBook.Instance.IncreaseNumberPhrase(-1);
		ItemSlotTxtBook.Instance.RemoveTxt(dragObject.GetComponent<TextMeshProUGUI>().text);
	}
}
