using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Weapons/Projectile Definition (Enemy)")]
public class EnemyProjectileDefinition : ProjectileDefinition
{
	private void OnEnable()
	{
		Layer = 15;
	}
}
