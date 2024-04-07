using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VectorGraphics;
using UnityEngine;

public class FullScreenBook : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> allTxt = new List<TextMeshProUGUI>();
    [SerializeField] private ScriptableObjectBook scriptableObjectBook;
	[SerializeField] private GameObject txtBook = default;
	[SerializeField] private List<GameObject> allContainerTxt = new List<GameObject>();

	public static FullScreenBook FullScreenBookinstance = default;

	private void Awake()
	{
		if (FullScreenBookinstance != this)
			FullScreenBookinstance = this;

		gameObject.SetActive(false);
	}

	private void Start()
	{
		Init();
	}

	public void ChangeText(List<ExcorsisteTxt> newText)
	{
		for (int i = 0; i < newText.Count; i++)
		{
			allTxt[i].text = newText[i].txt;
			allTxt[i].GetComponent<TxtSelected>().excorsisteText = newText[i];
		}
	}

	private void Init()
	{
		allTxt.Clear();

		foreach (var containerTxt in allContainerTxt)
		{
			if (containerTxt.transform.childCount != 0)
				Destroy(containerTxt.transform.GetChild(0).gameObject);
		}

		foreach (var containerTxt in allContainerTxt)
		{
			allTxt.Add(Instantiate(txtBook, containerTxt.transform).GetComponent<TextMeshProUGUI>());
		}

		SVGImage image = GetComponent<SVGImage>();
		image.sprite = scriptableObjectBook.sprite;
		ChangeText(scriptableObjectBook.txtExcorsiste);
	}

	public void Reset_()
	{
		Init();
	}
}
