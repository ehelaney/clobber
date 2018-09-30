using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectileWeaponLoot", menuName = "Loot/Projectile Weapon Loot Type")]
public class ProjectileWeaponLootType : LootType
{
	public ProjectileWeaponDefinition projectileWeaponDefinition;

	private void OnEnable()
	{
		lifeTime = 4.0f;
		if (projectileWeaponDefinition != null)	sprite = projectileWeaponDefinition.lootSprite;
	}

	public override void OnCollect()
	{
		PlayerInfo.Instance.ChangeProjectileWeapon(projectileWeaponDefinition);
	}
}