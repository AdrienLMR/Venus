using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
	private RectTransform rectTransform;

	virtual protected void Awake()
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
		RectTransform rt = dragObject.GetComponent<RectTransform>();

		dragObject.GetComponent<Dragdrop>().droped = true;
		dragObject.GetComponent<RectTransform>().anchoredPosition = /*rectTransform.anchoredPosition*/Vector2.zero;
		rt.offsetMax = Vector2.zero;
		rt.offsetMin = Vector2.zero;
	}

}
