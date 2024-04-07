using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSlotTxtBook : ItemSlot
{
	[SerializeField] private int maxNumberPhrase = 4;
	[SerializeField] private List<Transform> allContainerTxt = new List<Transform>();

	public static ItemSlotTxtBook Instance;

	private List<string> txtSave = new List<string>();
	private int actualNumberPhrase = 0;

	override protected void Awake()
	{
		base.Awake();

		if (Instance != this)
			Instance = this;
	}


	override protected void OnDropObject(GameObject dragObject)
	{
		if (actualNumberPhrase >= maxNumberPhrase)
			return;

		IncreaseNumberPhrase(1);

		foreach (var containerTxt in allContainerTxt)
		{
			if(containerTxt.childCount == 0)
				dragObject.transform.SetParent(containerTxt);
		}

		base.OnDropObject(dragObject);
		txtSave.Add(dragObject.GetComponent<TextMeshProUGUI>().text);
		ManagerSituation3.Instance.SaveText(txtSave);
	}

	public void IncreaseNumberPhrase(int numberToAdd)
	{
		actualNumberPhrase += numberToAdd;
		actualNumberPhrase = Mathf.Clamp(actualNumberPhrase,0, maxNumberPhrase);
	}

	public void RemoveTxt(string TxtToDelete)
	{
		txtSave.Remove(TxtToDelete);
		ManagerSituation3.Instance.SaveText(txtSave);
	}

	private void Reset_()
	{
		foreach (var txtToDeleted in txtSave)
		{
			RemoveTxt(txtToDeleted);
		}

		foreach (var containerTxt in allContainerTxt)
		{
			if (containerTxt.childCount > 0)
				Destroy(containerTxt.GetChild(0));
		}

		ManagerSituation3.Instance.SaveText(txtSave);
	}
}
