using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
	private RectTransform rectTransform;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
	}

	public void OnDrop(PointerEventData eventData)
	{
		GameObject dragObject = eventData.pointerDrag;

		if (dragObject != null)
		{
			OnDropObject(dragObject);
		}
	}

	virtual protected void OnDropObject(GameObject dragObject)
	{
		dragObject.GetComponent<RectTransform>().anchoredPosition = rectTransform.anchoredPosition;
	}

}
