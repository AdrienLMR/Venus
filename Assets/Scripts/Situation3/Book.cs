using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;


public delegate void OnClickedBook(Book sender);

public class Book : MonoBehaviour
{
	[SerializeField] private SC_Book scriptableObjectBook;

	public event OnClickedBook onClickedBook;

	private Button btn /*{ private get; private set; }*/;
	private FullScreenBook fullScreenBook;

	private void Awake()
	{
		btn = GetComponent<Button>();
		ButtonAddListner();
	}

	private void Start()
	{
		SVGImage image = GetComponent<SVGImage>();
		image.sprite = scriptableObjectBook.sprite;
		fullScreenBook = FullScreenBook.FullScreenBookinstance;
	}

	private void ButtonAddListner()
	{
		btn.onClick.AddListener(OnButtonClicked);
	}

	private void OnButtonClicked()
	{
		fullScreenBook.ChangeText(scriptableObjectBook.txt);
		onClickedBook?.Invoke(this);
	}
}
