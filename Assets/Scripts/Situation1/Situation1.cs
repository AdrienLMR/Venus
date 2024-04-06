using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class Situation1 : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Map map = default;
    [SerializeField] private ManagerSituation2 managerSituation2 = default;
    [SerializeField] private ManagerSituation3 managerSituation3 = default;
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

    public void Init(Sprite caracter)
    {
        this.caracter.sprite = caracter;
        caracterText.text = string.Empty;

        yes.enabled = false;
        no.enabled = false;
        situationObjects.enabled = false;
        situationTexts.enabled = false;
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
        caracter.sprite = null;
        caracter.color = new Color(0, 0, 0, 0);
    }
    #endregion

    #region Buttons
    private void Yes()
    {
        yes.enabled = false;
        no.enabled = false;
        situationObjects.enabled = true;
        situationTexts.enabled = true;
    }

    private void No()
    {
        Clean();
        Transition.TransitionTo(map.gameObject);
    }

    private void SituationObjects()
    {
        Transition.TransitionTo(managerSituation2.gameObject);
    }

    private void SituationTexts()
    {
        Transition.TransitionTo(managerSituation3.gameObject);
    }
    #endregion
}