using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void ManagerSituation2EventHandler(ManagerSituation2 sender, DemonObject demonObject);

public class ManagerSituation2 : MonoBehaviour
{
	[SerializeField] private Perso perso = default;
	[SerializeField] private Button btnValidate = default;
	[SerializeField] private List<DemonObject> allDemonObject = new List<DemonObject>();

	public static ManagerSituation2 Instance;

	private DemonObject actualdemonObject = default;

	public event ManagerSituation2EventHandler OnValidateObject;

	private void Awake()
	{
		if (Instance != this)
			Instance = this;
	}

	private void Start()
	{
		perso.Init();

		for (int i = 0; i < allDemonObject.Count; i++)
		{
			DemonObject demonObject = allDemonObject[i];

			demonObject.onClicked += DemonObject_onClicked;
			demonObject.scriptableObjectDemonObject = perso.scripatbleObjectPerso.allDemonObject[i];
			demonObject.Init();
		}

		btnValidate.onClick.AddListener(OnClickValidate);

		gameObject.SetActive(false);
	}

	private void OnClickValidate()
	{
		OnValidateObject?.Invoke(this, actualdemonObject);
	}

	private void DemonObject_onClicked(DemonObject sender)
	{
		actualdemonObject = sender;

		foreach (var demonObject in allDemonObject)
		{
			if (actualdemonObject != demonObject)
				demonObject.Deselected();
		}
	}

	public void Reset_()
	{

	}
}
