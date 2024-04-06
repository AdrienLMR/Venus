using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public delegate void TextAppearEventHandler(TextAppear sender);

[DisallowMultipleComponent]
public class TextAppear : MonoBehaviour
{
    private static TextAppear Instance { get; set; } = default;

    [Header("Objects")]
    private TextMeshProUGUI textMesh = default;

    [Header("Values")]
    private string text = string.Empty;
    private float timeToDisplay = 0f;

    private float elapsedTime = 0f;

    public static event TextAppearEventHandler OnFinished;

    private Action DoAction;

    #region Unity methods
    private void Start()
    {
        Instance = this;
        SetModeVoid();
    }

    private void Update()
    {
        DoAction();
    }
    #endregion

    public static void AppearProgressively(TextMeshProUGUI textMesh, string text, float timeToDisplay)
    {
        Instance.textMesh = textMesh;
        Instance.text = text;
        Instance.timeToDisplay = timeToDisplay;

        Instance.elapsedTime = 0;

        Instance.SetModePlay();
    }

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
        elapsedTime += Time.deltaTime;

        float percentage = elapsedTime / timeToDisplay;
        textMesh.text = text.Substring(0, Mathf.RoundToInt(text.Length * percentage));

        if (percentage >= 1)
        {
            SetModeVoid();
            OnFinished?.Invoke(this);
        }
    }
    #endregion
}
