using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnExorcismProcedure : MonoBehaviour
{
	[SerializeField] private int numberToSucces = 3;

	[SerializeField] private List<string> textWin = new List<string>();
	[SerializeField] private List<string> textLose = new List<string>();

    private Button btn;

	private void Awake()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(DoExorcismProcedure);
		gameObject.SetActive(false);
	}

	private void DoExorcismProcedure()
	{
		ScriptableObjectPerso scripatbleObjectPerso = LevelManager.Instance.currentPerso.scriptableObjectPerso;
		DemonObject actualDemonObject = LevelManager.Instance.actualdemonObject;
		bool isPosses = scripatbleObjectPerso.isPosses;

		if ((!isPosses || !actualDemonObject.scriptableObjectDemonObject.rightObject) || !CheckSentence())
		{
			Transition.TransitionTo(EndScreen.Instance.gameObject).AddCallbackInMiddle(() => gameObject.SetActive(false)).AddCallbackInEnd(() => SendExorcismText(true));
		}else /*(isPosses && CheckSentence() && actualDemonObject.scriptableObjectDemonObject.rightObject)*/
		{
			Transition.TransitionTo(EndScreen.Instance.gameObject).AddCallbackInMiddle(() => gameObject.SetActive(false)).AddCallbackInEnd(() => SendExorcismText(false));
		}

		FullScreenBook.FullScreenBookinstance.Reset_();
		ItemSlotTxtBook.Instance.Reset_();
		ManagerSituation3.Instance.Reset_();
	}

	private void SendExorcismText(bool win)
    {
		EndScreen.Instance.BeginText(win ? textWin : textLose);
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
