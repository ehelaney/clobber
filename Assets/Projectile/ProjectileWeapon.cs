using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
	public Transform m_Muzzle; // A child of the weapon where the projectile should spawn. The end of the barrel.
	public ProjectileWeaponTypeDef TypeDefinition;

	float timeSinceLastShot = 0.0f;

	public void Initialize(ProjectileWeaponTypeDef typeDef)
	{
		TypeDefinition = typeDef;
		timeSinceLastShot = 0.0f;
	}

	public void SetTypeDefinition(ProjectileWeaponTypeDef typeDef)
	{
		TypeDefinition = typeDef;
	}

	// Update is called once per frame
	void Update()
	{
		timeSinceLastShot += Time.deltaTime;
		if (Input.GetMouseButtonDown(0)) // Attack on mouse click - obviously this needs changed to a real input method
		{
			OnFire();
		}
	}

	public void OnFire()
	{
		if (timeSinceLastShot > TypeDefinition.RateOfFire)
		{
			//fire in the direction of the muzzle
			ProjectileFactory.TheFactory.SpawnNewProjectile(TypeDefinition.ProjectileType, transform.position, m_Muzzle.right, m_Muzzle.rotation);
			timeSinceLastShot = 0.0f;
		}
	}
}
