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

    //[SerializeField] private ... currentPerso = default;

    private void Awake()
    {
        map.OnClickHouse += Map_OnClickHouse;
    }

    #region events
    private void Map_OnClickHouse(Map sender, House house)
    {
        //currentPerso = house.perso;
        Transition.TransitionTo(situation1.gameObject);
    }
    #endregion

    public static void Clean()
    {

    }
}
