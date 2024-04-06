using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ExclamationPoint : MonoBehaviour, IPointerEnterHandler
{
	[SerializeField] private GameObject infoBubble = default;

	public void OnPointerEnter(PointerEventData eventData)
	{
		gameObject.SetActive(false);
		infoBubble.SetActive(true);
	}
}
