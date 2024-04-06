using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public delegate void OnClickedBook(Book sender);

public class Book : MonoBehaviour
{
	public event OnClickedBook onClickedBook;

	private Button btn /*{ private get; private set; }*/;
	
	private void Awake()
	{
		btn = GetComponent<Button>();
		ButtonAddListner();
	}

	private void ButtonAddListner()
	{
		btn.onClick.AddListener(OnButtonClicked);
	}

	private void OnButtonClicked()
	{
		onClickedBook?.Invoke(this);
	}
}
