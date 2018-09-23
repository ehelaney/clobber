using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName="Weapons/Melee Weapon Definition")]
public class MeleeWeaponDefinition : ScriptableObject
{
	public string Name;
	public int Damage;
	public Sprite sprite;
}
