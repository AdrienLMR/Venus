using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void HouseBtnEventHandler(HouseBtn sender);

public class HouseBtn : MonoBehaviour
{
    [SerializeField] public Perso perso;
    [SerializeField] public Sprite background;
	[HideInInspector] public bool isDone;
	[HideInInspector] public GameObject exclamation;

	public event HouseBtnEventHandler onClickHouse = default;

	public Button btn;

	private void Start()
	{
		btn = GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}

	private void OnClick()
	{
		onClickHouse?.Invoke(this);
	}

}
