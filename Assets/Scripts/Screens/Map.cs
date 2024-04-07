using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class House
{
    public Button button;
    public GameObject perso;
    [HideInInspector] public bool isDone;
    [HideInInspector] public GameObject exclamation;
}

public delegate void MapEventHandler(Map sender, House house);

[DisallowMultipleComponent]
public class Map : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Button quit = default;
    [SerializeField] private TitleScreen titleScreen = default;
    [SerializeField] private List<HouseBtn> houseList = default;

    public event MapEventHandler OnClickHouse;

    #region Unity Methods
    private void Awake()
    {
        quit.onClick.AddListener(Quit);
    }
    #endregion

    private void Quit()
    {
        Transition.TransitionTo(titleScreen.gameObject);
        LevelManager.Clean();
    }
}
