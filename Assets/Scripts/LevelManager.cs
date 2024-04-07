using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance = default;

    [Header("Objects")]
    [SerializeField] private Map map = default;
    [SerializeField] private Situation1 situation1 = default;
    [SerializeField] private ManagerSituation2 managerSituation2 = default;
    [SerializeField] private ManagerSituation3 managerSituation3 = default;
    [SerializeField] private BtnExorcismProcedure btnExorcismProcedure = default;
    [SerializeField] private List<HouseBtn> houseBtn = new List<HouseBtn>();

    [HideInInspector] public Perso currentPerso = default;
    [HideInInspector] public DemonObject actualdemonObject = default;
    [HideInInspector] public HouseBtn house = default;

    private void Awake()
    {
        Instance = this;

		foreach (var houseBtn in houseBtn)
		{
			houseBtn.onClickHouse += HouseBtn_onClickHouse;
		}

        managerSituation2.OnValidateObject += ManagerSituation2_OnValidateObject;
    }

	private void HouseBtn_onClickHouse(HouseBtn sender)
	{
        house = sender;
        currentPerso = sender.perso.GetComponent<Perso>();
        Transition.TransitionTo(situation1.gameObject).AddCallbackInMiddle(InitSituation1).AddCallbackInEnd(StartSituation1);
        ManagerSituation2.Instance.Init(currentPerso.scriptableObjectPerso, house.background);
    }

	#region Events
    private void ManagerSituation2_OnValidateObject(ManagerSituation2 sender, DemonObject demonObject)
    {
        actualdemonObject = demonObject;
        Transition.TransitionTo(managerSituation3.gameObject).AddCallbackInMiddle(InitSituation3);
    }
    #endregion

    private void InitSituation1()
    {
        situation1.Init(currentPerso.scriptableObjectPerso.sprite, house.background);
    }

    private void StartSituation1()
    {
        situation1.StartAppear(currentPerso.scriptableObjectPerso.txtIntroduction);
    }

    private void InitSituation3()
    {
        managerSituation3.Init(house.background);
    }

    public static void Clean()
    {
        Instance.house = null;
        Instance.currentPerso = null;
        Instance.actualdemonObject = null;
        Instance.btnExorcismProcedure.gameObject.SetActive(false);
    }
}
