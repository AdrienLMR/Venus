using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnExorcismProcedure : MonoBehaviour
{
	[SerializeField] private int numberToSucces = 3;

	[SerializeField] private List<string> text1 = new List<string>();
	[SerializeField] private List<string> text2 = new List<string>();
	[SerializeField] private List<string> text3 = new List<string>();

    private Button btn;

	private void Awake()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(DoExorcismProcedure);
		gameObject.SetActive(false);
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

		if ((!CheckSentence(out List<string> text) || !isPosses || !actualDemonObject.scriptableObjectDemonObject.rightObject) || actualDemonObject == null)
		{
			Transition.TransitionTo(EndScreen.Instance.gameObject).AddCallbackInMiddle(() => gameObject.SetActive(false)).AddCallbackInEnd(() => SendExorcismText(text));
		}else /*(isPosses && CheckSentence() && actualDemonObject.scriptableObjectDemonObject.rightObject)*/
		{
			Transition.TransitionTo(EndScreen.Instance.gameObject).AddCallbackInMiddle(() => gameObject.SetActive(false)).AddCallbackInEnd(() => SendExorcismText(text));
		}

		FullScreenBook.FullScreenBookinstance.Reset_();
		ItemSlotTxtBook.Instance.Reset_();
		ManagerSituation3.Instance.Reset_();
	}

	private void SendExorcismText(List<string> text)
    {
		EndScreen.Instance.BeginText(text);
	}

	private bool CheckSentence(out List<string> text)
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
		{
			text = text1;
			return true;
		}
		else if (proscrit >= 3)
		{
			text = text2;
			return true;
		}
		else
		{
			text = text3;
			return true;
		}
	}
}
