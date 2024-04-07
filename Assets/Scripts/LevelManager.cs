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
    [SerializeField] private List<HouseBtn> houseBtn = new List<HouseBtn>();

    [HideInInspector] public Perso currentPerso = default;
    [HideInInspector] public DemonObject actualdemonObject = default;

    private void Awake()
    {
        Instance = this;

		//map.OnClickHouse += Map_OnClickHouse;

		foreach (var houseBtn in houseBtn)
		{
			houseBtn.onClickHouse += HouseBtn_onClickHouse;
		}

        managerSituation2.OnValidateObject += ManagerSituation2_OnValidateObject;
    }

	private void HouseBtn_onClickHouse(HouseBtn sender)
	{
        currentPerso = sender.perso.GetComponent<Perso>();
        Transition.TransitionTo(situation1.gameObject).AddCallbackInMiddle(InitSituation1).AddCallbackInEnd(StartSituation1);
    }

	#region events
	private void Map_OnClickHouse(Map sender, House house)
    {
        currentPerso = house.perso.GetComponent<Perso>();
        Transition.TransitionTo(situation1.gameObject).AddCallbackInMiddle(InitSituation1).AddCallbackInEnd(StartSituation1);
    }

    private void ManagerSituation2_OnValidateObject(ManagerSituation2 sender, DemonObject demonObject)
    {
        actualdemonObject = demonObject;
        Transition.TransitionTo(managerSituation3.gameObject);
    }
    #endregion

    private void InitSituation1()
    {
        situation1.Init(currentPerso.scripatbleObjectPerso.sprite);
    }

    private void StartSituation1()
    {
        situation1.StartAppear(currentPerso.scripatbleObjectPerso.txtIntroduction);
    }

    public static void Clean()
    {
        Instance.currentPerso = null;
        Instance.actualdemonObject = null;
    }
}
