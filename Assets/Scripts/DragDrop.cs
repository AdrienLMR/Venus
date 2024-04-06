using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragdrop : MonoBehaviour, IBeginDragHandler,IEndDragHandler, IDragHandler
{
	[SerializeField] private Canvas canvas;

	public bool droped;

	private RectTransform rectTransform;
	private CanvasGroup canvasGroup;
	private Vector3 startPosition;
	
	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = false;
		startPosition = rectTransform.anchoredPosition;
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
		rectTransform.anchoredPosition = startPosition;
	}
}
