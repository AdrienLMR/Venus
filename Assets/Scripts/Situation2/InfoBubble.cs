using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class InfoBubble : MonoBehaviour, IPointerExitHandler
{
	[SerializeField] private GameObject exclamationPoint = default;

	private void Start()
	{
		gameObject.SetActive(false);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		exclamationPoint.SetActive(true);
		gameObject.SetActive(false);
	}
}
