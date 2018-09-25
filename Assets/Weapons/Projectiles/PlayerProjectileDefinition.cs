using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Weapons/Projectile Definition (Player)")]
public class PlayerProjectileDefinition : ProjectileDefinition
{
	private void OnEnable()
	{
		Layer = 14;
	}
}
