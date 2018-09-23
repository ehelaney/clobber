using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFactory : MonoBehaviour
{
	private static ProjectileFactory theProjectileFactory;
	public static ProjectileFactory TheFactory
	{
		get
		{
			return theProjectileFactory;
		}

	}

	public ObjectPool projectilePool; //may need a separate object pool for each projectile type.  So maybe this needs updated to be an array?

	// Use this for initialization
	void Start()
	{
		projectilePool.Initialize();
		theProjectileFactory = this;
	}

	private void OnDestroy()
	{
		if (theProjectileFactory == this)
		{
			theProjectileFactory = null;
		}
	}

	public void SpawnNewProjectile(ProjectileDefinition projectileDefintion, Vector2 pos, Vector2 direction, Quaternion rotation)
	{
		var newProjectile = projectilePool.InitNewObject();
		newProjectile.GetComponent<Projectile>().Initialize(projectileDefintion, pos, direction, rotation);
	}

	public void KillAllProjectiles()
	{
		projectilePool.DeactivateAll();
	}
}