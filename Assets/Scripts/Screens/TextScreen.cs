using System.Collections.Generic;
using TMPro;
using UnityEngine;

public delegate void TextScreenEventHandler(TextScreen sender);

[DisallowMultipleComponent]
public class TextScreen : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private TextMeshProUGUI textMesh = default;

    [Header("Values")]
    [SerializeField] private float timeToDisplay = 0f;

    private event TextScreenEventHandler OnFinished;

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
