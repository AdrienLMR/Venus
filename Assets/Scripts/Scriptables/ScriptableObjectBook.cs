using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Book", menuName = "ScriptableObjects/Book")]
public class ScriptableObjectBook : ScriptableObject
{
	public Sprite sprite;
	public List<ExcorsisteTxt> txtExcorsiste = new List<ExcorsisteTxt>();
}
