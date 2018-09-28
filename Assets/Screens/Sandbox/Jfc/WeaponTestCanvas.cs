using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTestCanvas : MonoBehaviour
{
	public Player player;
	public ProjectileWeaponDefinition laserWeapon;
	public ProjectileWeaponDefinition machineGun;
	public ProjectileWeaponDefinition missileLauncher;

	public void EquipLaserWeapon()
	{
		player.EquipProjectileWeapon(laserWeapon);
	}

	public void EquipMachineGun()
	{
		player.EquipProjectileWeapon(machineGun);
	}

	public void EquipMissileLauncher()
	{
		player.EquipProjectileWeapon(missileLauncher);
	}
}

