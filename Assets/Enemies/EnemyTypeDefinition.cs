using System;
using UnityEngine;

[Serializable]
public class EnemyTypeDefinition
{
	public int ID; //should this be an enum instead?
	public string HelpfulName;
	public Sprite Sprite;
	public int PointsForKilling;
}
