using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class CreditsScreen : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject creditsContainer = default;
    [SerializeField] private Button quit = default;

    [Header("Values")]
    [SerializeField] private float speed = default;

    private Action DoAction;

    #region Unity Methods
    private void Awake()
    {
        SetModeVoid();
    }

    public void Init()
    {
        SetModePlay();
    }

    private void Update()
    {
        DoAction();
    }
    #endregion

    #region State Machine		
    public void SetModeVoid()
    {
        DoAction = DoActionVoid;
    }

    public void SetModePlay()
    {
        DoAction = DoActionPlay;
    }

    private void DoActionVoid() { }

    private void DoActionPlay()
    {
        creditsContainer.transform.position += Time.deltaTime * speed * Vector3.up;

        if (creditsContainer.transform.position.y > 3000)
            SetModeVoid();
    }
    #endregion

    private void Quit()
    {

    }
}
