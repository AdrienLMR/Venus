using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
public class TitleScreen : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TutoScreen tutoScreen = default;
    [SerializeField] private CreditsScreen creditsScreen = default;

    [SerializeField] private Button play = default;
    [SerializeField] private Button credits = default;
    [SerializeField] private Button quit = default;

    #region Unity Methods
    private void Awake()
    {
        play.onClick.AddListener(Play);
        credits.onClick.AddListener(Credits);
        quit.onClick.AddListener(Quit);
    }
    #endregion

    private void Play()
    {
        Transition.TransitionTo(tutoScreen.gameObject).AddCallbackInEnd(tutoScreen.Init);
    }

    private void Credits()
    {
        Transition.TransitionTo(creditsScreen.gameObject);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
