using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class TextAppear : MonoBehaviour
{
    private static TextAppear Instance { get; set; } = default;

    [Header("Objects")]
    private TextMeshProUGUI textMesh = default;

    [Header("Values")]
    private List<string> text = new List<string>();
    private float timeToDisplay = 0f;

    private float elapsedTime = 0f;

    private int textIndex = 0;

    private Action CallBackOnFinished;
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

    public static void AppearProgressively(TextMeshProUGUI textMesh, List<string> text, float timeToDisplay, Action CallBackOnFinished = null)
    {
        Instance.textMesh = textMesh;
        Instance.text = text;
        Instance.timeToDisplay = timeToDisplay;

        Instance.CallBackOnFinished = CallBackOnFinished;

        Instance.elapsedTime = 0f;
        Instance.textIndex = 0;

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

    public void SetModeWaitForInput()
    {
        DoAction = DoActionWaitForInput;
    }

    private void DoActionVoid() { }

    private void DoActionPlay()
    {
        elapsedTime += Time.deltaTime;

        float percentage = elapsedTime / timeToDisplay;
        textMesh.text = text[textIndex].Substring(0, Mathf.RoundToInt(text[textIndex].Length * percentage));

        if (percentage >= 1)
        {
            SetModeWaitForInput();
        }
        else if (Input.anyKeyDown)
        {
            textMesh.text = text[textIndex];
            SetModeWaitForInput();
        }
    }

    private void DoActionWaitForInput()
    {
        if (Input.anyKeyDown)
        {
            elapsedTime = 0f;
            textMesh.text = string.Empty;

            if (textIndex < text.Count - 1)
            {
                textIndex += 1;
                SetModePlay();
            }
            else
            {
                textIndex = 0;
                SetModeVoid();
                CallBackOnFinished();
            }
        }
    }
    #endregion
}
