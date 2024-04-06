using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FullScreenBook : MonoBehaviour
{
    [SerializeField] private List<TextMeshProUGUI> allTxt = new List<TextMeshProUGUI>();

	public static FullScreenBook FullScreenBookinstance = default;

	private void Awake()
	{
		if (FullScreenBookinstance != this)
			FullScreenBookinstance = this;

		gameObject.SetActive(false);
	}

	public void ChangeText(List<string> newText)
	{
		for (int i = 0; i < newText.Count; i++)
		{
			allTxt[i].text = newText[i];
		}
	}
}
