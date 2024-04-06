using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;

public class Perso : MonoBehaviour
{
	public ScriptableObjectPerso scripatbleObjectPerso = default;

	public void Init()
	{
		GetComponent<SVGImage>().sprite = scripatbleObjectPerso.sprite;
	}
}
