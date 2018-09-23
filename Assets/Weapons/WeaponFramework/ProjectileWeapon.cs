using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
	public Transform m_Muzzle; // The end of the barrel.
	private ProjectileWeaponDefinition weaponDefinition;

	float timeSinceLastShot = 0.0f;

	public void SetWeaponDefinition(ProjectileWeaponDefinition typeDef)
	{
		weaponDefinition = typeDef;
		timeSinceLastShot = 0.0f;
	}

	// Update is called once per frame
	void Update()
	{
		timeSinceLastShot += Time.deltaTime;
	}

	public void OnFire()
	{
		if (timeSinceLastShot > weaponDefinition.TimeBetweenShots)
		{
			//fire in the direction of the muzzle
			ProjectileFactory.TheFactory.SpawnNewProjectile(weaponDefinition.ProjectileType, m_Muzzle.position, m_Muzzle.right, m_Muzzle.rotation);
			SoundManager.Instance.PlaySound(weaponDefinition.OnShootSound, m_Muzzle.position);
			timeSinceLastShot = 0.0f;
		}
	}
}
