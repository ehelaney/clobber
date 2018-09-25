using UnityEngine;

public abstract class ProjectileDefinition : ScriptableObject
{
	public string Name;
	public float Speed;
	public int Damage;
	public Sprite sprite;

	[HideInInspector]
	public int Layer;
}
