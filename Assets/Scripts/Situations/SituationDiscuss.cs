using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class SituationDiscuss : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Image person = default;
    [SerializeField] private TextMeshProUGUI personText = default;

    [SerializeField] private Button yes = default;
    [SerializeField] private Button no = default;

    [Header("Values")]
    [SerializeField] private float timeToDisplayText = 0f;

    #region Unity Methods
    private void Awake()
    {
        yes.onClick.AddListener(SelectYes);
        no.onClick.AddListener(SelectNo);
    }

    private void Init(Sprite person, string text)
    {
        TextAppear.OnFinished += TextAppear_OnFinished;
        TextAppear.AppearProgressively(personText, text, timeToDisplayText);

        this.person.sprite = person;
    }
    #endregion

    #region Buttons
    private void SelectYes()
    {

    }

    private void SelectNo()
    {

    }
    #endregion

    #region Events
    private void TextAppear_OnFinished(TextAppear sender)
    {
        TextAppear.OnFinished -= TextAppear_OnFinished;

        Debug.Log("finished");
    }
    #endregion
}