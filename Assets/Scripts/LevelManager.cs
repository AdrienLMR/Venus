using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class LevelManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Map map = default;
    [SerializeField] private Situation1 situation1 = default;

    private Perso currentPerso = default;

    private void Awake()
    {
        map.OnClickHouse += Map_OnClickHouse;
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
