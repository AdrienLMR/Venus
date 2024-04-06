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

    public void BeginText(string text)
    {
        TextAppear.OnFinished += TextAppear_OnFinished;
        TextAppear.AppearProgressively(textMesh, text, timeToDisplay);
    }

    private void TextAppear_OnFinished(TextAppear sender)
    {
        TextAppear.OnFinished -= TextAppear_OnFinished;
        OnFinished?.Invoke(this);
    }
}
