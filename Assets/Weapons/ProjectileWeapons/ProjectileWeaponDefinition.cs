using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/Projectile Weapon Definition")]
public class ProjectileWeaponDefinition : ScriptableObject
{
	public string Name;
	public ProjectileDefinition ProjectileType;
	public float TimeBetweenShots;
	public SoundDefinition OnShootSound;
	public Sprite sprite;
	public Sprite lootSprite;
}