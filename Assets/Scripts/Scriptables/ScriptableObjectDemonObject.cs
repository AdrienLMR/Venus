using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DemonObject", menuName = "ScriptableObjects/Object")]
public class ScriptableObjectDemonObject : ScriptableObject
{
	public Sprite sprite = default;
	public string objectName = default;
	public string txtDescription = default;
	public bool rightObject = false;
}
