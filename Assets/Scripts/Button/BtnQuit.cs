using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnQuit : MonoBehaviour
{
    private Button btn;

	private void Awake()
	{
        btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{

	}
}
