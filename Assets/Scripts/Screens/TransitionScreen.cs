using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public delegate void TransitionScreenEventHandler(TransitionScreen sender);

[DisallowMultipleComponent]
public class TransitionScreen : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private Image foreground = default;
    [SerializeField] private GameObject startScreen = default;

    private GameObject currentScreen = default;
    private GameObject nextScreen = default;

    [Header("Values")]
    [SerializeField] private float timeToAppear = 0f;
    [SerializeField] private float timeBetweenLoad = 0f;
    [SerializeField] private float timeToDisappear = 0f;

    public event TransitionScreenEventHandler OnMiddleTransition;
    public event TransitionScreenEventHandler OnEndTransition;

    #region Unity Methods
    private void Start()
    {
        currentScreen = startScreen;
    }
    #endregion

    public void TransitionTo(GameObject nextScreen)
    {
        this.nextScreen = nextScreen;

        StartCoroutine(Appear());
    }

    private IEnumerator Appear()
    {
        float elapsedTime = 0f;

        while (elapsedTime < timeToAppear)
        {
            elapsedTime += Time.deltaTime;

            foreground.color = new Color(foreground.color.r, foreground.color.g, foreground.color.b, elapsedTime / timeToAppear);

            yield return null;
        }

        LoadDeloadScreen();
    }

    private void LoadDeloadScreen()
    {
        currentScreen.SetActive(false);
        nextScreen.SetActive(true);

        currentScreen = nextScreen;

        OnMiddleTransition?.Invoke(this);

        StartCoroutine(BetweenLoad());
    }

    private IEnumerator BetweenLoad()
    {
        yield return new WaitForSeconds(timeBetweenLoad);

        StartCoroutine(Disappear());
    }

    private IEnumerator Disappear()
    {
        float elapsedTime = timeToDisappear;

        while (elapsedTime > 0f)
        {
            elapsedTime -= Time.deltaTime;

            foreground.color = new Color(foreground.color.r, foreground.color.g, foreground.color.b, elapsedTime / timeToDisappear);

            yield return new WaitForEndOfFrame();
        }

        OnEndTransition?.Invoke(this);
    }
}