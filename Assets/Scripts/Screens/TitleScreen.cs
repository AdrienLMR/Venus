using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class TitleScreen : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Button play = default;
    [SerializeField] private Button credits = default;
    [SerializeField] private Button quit = default;

    #region Unity Methods
    private void Awake()
    {
        play.onClick.AddListener(Play);
        credits.onClick.AddListener(Credits);
        quit.onClick.AddListener(Quit);
    }
    #endregion

    private void Play()
    {

    }

    private void Credits()
    {

    }

    private void Quit()
    {
        Application.Quit();
    }
}
