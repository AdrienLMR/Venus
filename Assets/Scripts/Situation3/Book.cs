using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;


public delegate void OnClickedBook(Book sender, FullScreenBook fullScreenBook);

public class Book : MonoBehaviour
{
	[SerializeField] private FullScreenBook fullScreenBook;

	public event OnClickedBook onClickedBook;

	private Button btn /*{ private get; private set; }*/;

	private void Awake()
	{
		//Debug.LogError("Adrien qui fait des init c'est vraiment un truc de merde, faut aller se faire foutre");
		btn = GetComponent<Button>();
		ButtonAddListner();
		SVGImage image = GetComponent<SVGImage>();
	}

	private void ButtonAddListner()
	{
		btn.onClick.AddListener(OnButtonClicked);
	}

	private void OnButtonClicked()
	{
		//fullScreenBook.ChangeText(scriptableObjectBook.txt);
		onClickedBook?.Invoke(this, fullScreenBook);
	}
}
