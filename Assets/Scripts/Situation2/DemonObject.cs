using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.UI;

public delegate void OnClickedDemonobject(DemonObject sender);

public class DemonObject : MonoBehaviour
{
	[SerializeField] private SVGImage objectImage;

	public event OnClickedDemonobject onClicked = default;

	public ScriptableObjectDemonObject scriptableObjectDemonObject = default;

	private Button btn;
	private string objectName;
	private SVGImage image = default;

	public void Init()
	{
		objectImage.sprite = scriptableObjectDemonObject.sprite;
		objectName = scriptableObjectDemonObject.name;
		image = GetComponent<SVGImage>();
	}

	public void Selected()
	{
		image.color = Color.red;
	}

	public void Deselected()
	{
		image.color = Color.white;
	} 

	private void Awake()
	{
		btn = GetComponent<Button>();		
	}

	private void Start()
	{
		btn.onClick.AddListener(OnClickBtn);
	}

	private void OnClickBtn()
	{
		Selected();
		onClicked?.Invoke(this);
	}
}
