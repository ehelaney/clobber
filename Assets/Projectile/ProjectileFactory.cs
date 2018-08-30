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

	public ProjectileTypeDef[] projectileTypes;

	public ObjectPool projectilePool; //may need a separate object pool for each projectile type.  So maybe this needs updated to be an array?

	private Dictionary<ProjectileType, ProjectileTypeDef> projectileTypeDefMap = new Dictionary<ProjectileType, ProjectileTypeDef>();


	// Use this for initialization
	void Start()
	{

		projectilePool.Initialize();
		theProjectileFactory = this;

		for (int i = 0; i < projectileTypes.Length; i++)
		{
			var projectileType = projectileTypes[i];
			projectileTypeDefMap.Add(projectileType.ProjectileType, projectileType);
		}
	}

	private void OnDestroy()
	{
		if (theProjectileFactory == this)
		{
			theProjectileFactory = null;
		}
	}

	public void SpawnNewProjectile(ProjectileType projectileType, Vector2 pos, Vector2 direction)
	{
		var newProjectile = projectilePool.InitNewObject();
		var typeDef = projectileTypeDefMap[projectileType];
		newProjectile.GetComponent<Projectile>().Initialize(typeDef, pos, direction);
		//newProjectile.layer = (int)typeDef.Layer;
	}

	public void KillAllProjectiles()
	{
		projectilePool.DeactivateAll();
	}
}