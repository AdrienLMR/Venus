using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnClickedBtnBack(BtnBackSituation3 sender);

public class BtnBackSituation3 : MonoBehaviour
{
	public event OnClickedBtnBack onClickedBtnBack;

	private Button btn;

	private void Awake()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(onClick);
	}

	private void onClick()
	{
		onClickedBtnBack?.Invoke(this);
	}
}
