using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Perso", menuName = "ScriptableObjects/Perso")]
public class ScriptableObjectPerso : ScriptableObject
{
	public Sprite sprite;
	public List<ScriptableObjectDemonObject> allDemonObject = new List<ScriptableObjectDemonObject>();
	public List<string> txtIntroduction = new List<string>();
	//public List<ExcorsisteTxt> txtExcorsiste = new List<ExcorsisteTxt>();
	public bool isPosses = false;
}
