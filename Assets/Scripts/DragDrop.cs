using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dragdrop : MonoBehaviour, IBeginDragHandler,IEndDragHandler, IDragHandler
{
	[SerializeField] private Canvas canvas;

	[HideInInspector]
	public bool droped = false;
	[HideInInspector]
	public Transform bookFullScreen;

	private RectTransform rectTransform;
	private CanvasGroup canvasGroup;
	private Vector3 startPosition;
	private Transform parent;
	
	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvasGroup = GetComponent<CanvasGroup>();
	}

	private void Start()
	{
		bookFullScreen = transform.parent;
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = false;
		startPosition = rectTransform.anchoredPosition;
		parent = transform.parent;
		droped = false;

		Canvas canvas = (Canvas)FindObjectOfType(typeof(Canvas));
		transform.SetParent(canvas.transform);
	}

	public void OnDrag(PointerEventData eventData)
	{
		rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		canvasGroup.blocksRaycasts = true;
		rectTransform.anchoredPosition = startPosition;

		if(!droped)
			transform.SetParent(parent);
	}
}
