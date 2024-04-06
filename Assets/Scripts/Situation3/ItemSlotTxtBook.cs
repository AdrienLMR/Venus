using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlotTxtBook : ItemSlot
{
	override protected void OnDropObject(GameObject dragObject)
	{
		base.OnDropObject(dragObject);
		dragObject.transform.SetParent(transform);
	}
}
