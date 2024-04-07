using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnSaveTxt : MonoBehaviour
{
	private Button btn;

	private void Start()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(SaveText);
	}

	private void SaveText()
	{
		foreach (var item in ManagerSituation3.Instance.saveTxt)
		{
			Debug.Log("Txt save : " + item);
		}
	}
}
