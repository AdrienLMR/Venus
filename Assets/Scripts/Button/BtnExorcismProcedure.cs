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

	private void Start()
	{
		gameObject.SetActive(false);
	}

	private void DoExorcismProcedure()
	{
		ScriptableObjectPerso scripatbleObjectPerso = LevelManager.Instance.currentPerso.scriptableObjectPerso;
		DemonObject actualDemonObject = LevelManager.Instance.actualdemonObject;
		bool isPosses = scripatbleObjectPerso.isPosses;

		if ((!isPosses || !actualDemonObject.scriptableObjectDemonObject.rightObject || !CheckSentence()) || actualDemonObject == null)
		{
			Debug.Log("C'est pas un possede");
		}else /*(isPosses && CheckSentence() && actualDemonObject.scriptableObjectDemonObject.rightObject)*/
		{
			Debug.Log("T'as reussi");
		}
	}

	private bool CheckSentence()
	{
		List<ExcorsisteTxt> selectedTxt = ManagerSituation3.Instance.saveTxt;
		int officiel = 0;
		int proscrit = 0;
		int bullshit = 0;

		foreach (var txtSelected in selectedTxt)
		{
			if (txtSelected.enumTxt == Enum_Txt.OFFICIEL)
				officiel++;
			else if (txtSelected.enumTxt == Enum_Txt.PROSCRIT)
				proscrit++;
			else
				bullshit++;
		}

		if (officiel >= 3)
			return true;
		else if (proscrit >= 3)
			return true;
		else
			return false;
	}
}
