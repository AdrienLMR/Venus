using System.Collections;
using System.Collections.Generic;
using Unity.VectorGraphics;
using UnityEngine;

public class Perso : MonoBehaviour
{
	public ScriptableObjectPerso scriptableObjectPerso = default;

	public void Init(ScriptableObjectPerso scriptableObjectPerso)
	{
		this.scriptableObjectPerso = scriptableObjectPerso;
		GetComponent<SVGImage>().sprite = scriptableObjectPerso.sprite;
	}
}
