using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Situation1 : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Image backgroundImage = default;
    [SerializeField] private Map map = default;
    [SerializeField] private ManagerSituation2 managerSituation2 = default;
    [SerializeField] private ManagerSituation3 managerSituation3 = default;
    [SerializeField] private BtnExorcismProcedure btnExorcismProcedure = default;
    [SerializeField] private Image caracter = default;
    [SerializeField] private TextMeshProUGUI caracterText = default;
    [SerializeField] private GameObject questionContainer = default;

    [SerializeField] private Button yes = default;
    [SerializeField] private Button no = default;
    [SerializeField] private Button situationObjects = default;
    [SerializeField] private Button situationTexts = default;
    [SerializeField] private GameObject excorsismeButton = default;

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

    public void Init(Sprite caracter, Sprite background)
    {
        this.caracter.sprite = caracter;
        caracterText.text = string.Empty;
        backgroundImage.sprite = background;

        yes.enabled = false;
        no.enabled = false;
        situationObjects.gameObject.SetActive(false);
        situationTexts.gameObject.SetActive(false);
        excorsismeButton.SetActive(true);
    }

    public void StartAppear(List<string> text)
    {
        TextAppear.AppearProgressively(caracterText, text, timeToDisplayText, EndAppear);
    }

    private void EndAppear()
    {
        yes.enabled = true;
        no.enabled = true;
    }

    private void Clean()
    {
        caracterText.text = string.Empty;
        questionContainer.SetActive(true);
    }
    #endregion

    #region Buttons
    private void Yes()
    {
        yes.enabled = false;
        no.enabled = false;
        situationObjects.gameObject.SetActive(true);
        situationTexts.gameObject.SetActive(true);
        questionContainer.SetActive(false);
        btnExorcismProcedure.gameObject.SetActive(false);

        TextAppear.AppearProgressively(caracterText, LevelManager.Instance.currentPerso.scriptableObjectPerso.yesHelp, timeToDisplayText);
    }

    private void No()
    {
        TextAppear.AppearProgressively(caracterText, LevelManager.Instance.currentPerso.scriptableObjectPerso.yesHelp, timeToDisplayText, EndNo);
    }

    private void EndNo()
    {
        Clean();
        Transition.TransitionTo(map.gameObject);
    }

    private void SituationObjects()
    {
        Transition.TransitionTo(managerSituation2.gameObject)/*.AddCallbackInMiddle(Clean)*/;
        excorsismeButton.SetActive(false);
    }

    private void SituationTexts()
    {
        Transition.TransitionTo(managerSituation3.gameObject)/*.AddCallbackInMiddle(Clean)*/;
        excorsismeButton.SetActive(false);
    }
    #endregion
}