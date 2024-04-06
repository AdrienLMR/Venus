using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[DisallowMultipleComponent]
public class TextScreen : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI textMesh = default;

    [Header("Values")]
    [SerializeField] private float timeToDisplay = 0f;

    public void CleanText()
    {
        textMesh.text = string.Empty;
    }

    public void BeginText(string text)
    {
        TextAppear.AppearProgressively(textMesh, text, timeToDisplay);
        TextAppear.OnFinished += TextAppear_OnFinished;
    }

    #region Events
    private void TextAppear_OnFinished(TextAppear sender)
    {
        TextAppear.OnFinished -= TextAppear_OnFinished;

        Debug.Log("finished");
    }
    #endregion
}
