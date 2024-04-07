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

    public Perso currentPerso = default;
    public DemonObject actualdemonObject = default;

    private void Awake()
    {
        Instance = this;

        map.OnClickHouse += Map_OnClickHouse;
        //managerSituation2.
    }

    #region events
    private void Map_OnClickHouse(Map sender, House house)
    {
        currentPerso = house.perso;
        Transition.TransitionTo(situation1.gameObject).AddCallbackInMiddle(InitSituation1).AddCallbackInEnd(StartSituation1);
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

    }
}
