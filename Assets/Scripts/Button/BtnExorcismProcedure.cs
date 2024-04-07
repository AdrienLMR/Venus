using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnExorcismProcedure : MonoBehaviour
{
	[SerializeField] private int numberToSucces = 3;

    private Button btn;

	private void Awake()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(DoExorcismProcedure);
	}

	private void DoExorcismProcedure()
	{
		ScriptableObjectPerso scripatbleObjectPerso = LevelManager.Instance.currentPerso.scriptableObjectPerso;
		DemonObject actualDemonObject = LevelManager.Instance.actualdemonObject;
		bool isPosses = scripatbleObjectPerso.isPosses;

		if ((!isPosses || !actualDemonObject.scriptableObjectDemonObject.rightObject) || !CheckSentence())
		{
			Debug.Log("C'est pas un possede");
		}else /*(isPosses && CheckSentence() && actualDemonObject.scriptableObjectDemonObject.rightObject)*/
		{
			Debug.Log("T'as reussi");
		}
	}

	private bool CheckSentence()
	{
		List<string> selectedTxt = ManagerSituation3.Instance.saveTxt;
		int rightTxt = 0;
		Perso currentPerso = LevelManager.Instance.currentPerso;

		foreach (var txtSelected in selectedTxt)
		{
			foreach (var txtExcorsiste in currentPerso.scriptableObjectPerso.txtExcorsiste)
			{
				Debug.Log(txtExcorsiste);
				Debug.Log(txtSelected);

				if (txtSelected == txtExcorsiste.txt)
					rightTxt++;

			}
		}

		return rightTxt >= numberToSucces;
	}
}
