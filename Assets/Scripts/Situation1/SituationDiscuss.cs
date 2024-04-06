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
    [SerializeField] private Map map = default;
    [SerializeField] private Image caracter = default;
    [SerializeField] private TextMeshProUGUI caracterText = default;

    [SerializeField] private Button yes = default;
    [SerializeField] private Button no = default;
    [SerializeField] private Button quit = default;
    [SerializeField] private Button situationObjects = default;
    [SerializeField] private Button situationTexts = default;

    [Header("Values")]
    [SerializeField] private float timeToDisplayText = 0f;

    #region Unity Methods
    private void Awake()
    {
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
        quit.onClick.AddListener(Quit);
        situationObjects.onClick.AddListener(SituationObjects);
        situationTexts.onClick.AddListener(SituationTexts);
    }

    private void Clean()
    {
        caracterText.text = string.Empty;
        caracter.sprite = null;
        caracter.color = new Color(0, 0, 0, 0);
    }

    private void Init(Sprite person, string text)
    {
        TextAppear.OnFinished += TextAppear_OnFinished;
        TextAppear.AppearProgressively(caracterText, text, timeToDisplayText);

        this.caracter.sprite = person;
    }
    #endregion

    #region Buttons
    private void Yes()
    {

    }

    private void No()
    {

    }

    private void Quit()
    {
        Clean();
        Transition.TransitionTo(map.gameObject);
    }

    private void SituationObjects()
    {

    }

    private void SituationTexts()
    {

    }
    #endregion

    #region Events
    private void TextAppear_OnFinished(TextAppear sender)
    {
        TextAppear.OnFinished -= TextAppear_OnFinished;
    }
    #endregion
}