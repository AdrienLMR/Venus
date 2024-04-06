using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Situation1 : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Map map = default;
    [SerializeField] private Image caracter = default;
    [SerializeField] private TextMeshProUGUI caracterText = default;

    [SerializeField] private Button yes = default;
    [SerializeField] private Button no = default;
    [SerializeField] private Button situationObjects = default;
    [SerializeField] private Button situationTexts = default;

    [Header("Values")]
    [SerializeField] private float timeToDisplayText = 0f;

    #region Unity Methods
    private void Awake()
    {
        yes.onClick.AddListener(Yes);
        no.onClick.AddListener(No);
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
        yes.enabled = false;
        no.enabled = false;
        situationObjects.enabled = false;
        situationTexts.enabled = false;

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
        yes.enabled = true;
        no.enabled = true;
        situationObjects.enabled = true;
        situationTexts.enabled = true;

        TextAppear.OnFinished -= TextAppear_OnFinished;
    }
    #endregion
}