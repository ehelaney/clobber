using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Projectile Definition")]
public class ProjectileDefinition : ScriptableObject
{
	public string Name;
	public float Speed;
	public int Damage;
	public Sprite sprite;
}
