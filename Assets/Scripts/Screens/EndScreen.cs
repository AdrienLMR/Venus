using System.Collections.Generic;
using TMPro;
using UnityEngine;

public delegate void EndScreenEventHandler(EndScreen sender);

[DisallowMultipleComponent]
public class EndScreen : MonoBehaviour
{
    public static EndScreen Instance = default;

    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI textMesh = default;

    [Header("Values")]
    [SerializeField] private float timeToDisplay = 0f;

    private event EndScreenEventHandler OnFinished;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void CleanText()
    {
        textMesh.text = string.Empty;
    }

    public void BeginText(List<string> text)
    {
        TextAppear.AppearProgressively(textMesh, text, timeToDisplay, EndTextAppear);
    }

    private void EndTextAppear()
    {
        OnFinished?.Invoke(this);
    }
}
