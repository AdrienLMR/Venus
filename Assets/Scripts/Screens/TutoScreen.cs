using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class TutoScreen : MonoBehaviour
{
    public static TutoScreen Instance { get; private set; } = default;

    [Header("Objects")]
    [SerializeField] private Map map = default;
    [SerializeField] private GameObject textContainer = default;
    [SerializeField] private TextMeshProUGUI textMesh = default;

    [Header("Values")]
    [SerializeField] private List<string> text = default;
    [SerializeField] private float timeToDisplay = default;

    private Action DoAction;

    #region Unity Methods
    private void Awake()
    {
        SetModeVoid();
    }

    public void Init()
    {
        textContainer.SetActive(true);
        TextAppear.AppearProgressively(textMesh, text, timeToDisplay, OnTextAppeared);
    }

    private void Update()
    {
        DoAction();
    }
    #endregion

    #region State machine
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
        if (Input.anyKeyDown)
        {
            Transition.TransitionTo(map.gameObject);
            SetModeVoid();
            textContainer.SetActive(false);
        }
    }
    #endregion

    private void OnTextAppeared()
    {
        SetModePlay();
    }
}
