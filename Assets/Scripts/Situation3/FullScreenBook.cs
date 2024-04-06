using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;

public class FullScreenBook : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> allTxt = new List<TextMeshProUGUI>();
    [SerializeField] private SC_Book scriptableObjectBook;

	public static FullScreenBook FullScreenBookinstance = default;

	private void Awake()
	{
		if (FullScreenBookinstance != this)
			FullScreenBookinstance = this;

		gameObject.SetActive(false);
	}

	private void Start()
	{
		ChangeText(scriptableObjectBook.txt);

		SVGImage image = GetComponent<SVGImage>();
		image.sprite = scriptableObjectBook.sprite;
	}

	public void ChangeText(List<string> newText)
	{
		for (int i = 0; i < newText.Count; i++)
		{
			allTxt[i].text = newText[i];
		}
	}
}
