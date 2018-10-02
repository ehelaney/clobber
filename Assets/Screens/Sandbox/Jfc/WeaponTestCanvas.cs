using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTestCanvas : MonoBehaviour
{
	public ProjectileWeaponDefinition laserWeapon;
	public ProjectileWeaponDefinition machineGun;
	public ProjectileWeaponDefinition missileLauncher;

	public void EquipLaserWeapon()
	{
		PlayerInfo.Instance.ChangeProjectileWeapon(laserWeapon);
	}

	public void EquipMachineGun()
	{
		PlayerInfo.Instance.ChangeProjectileWeapon(machineGun);
	}

	public void EquipMissileLauncher()
	{
		PlayerInfo.Instance.ChangeProjectileWeapon(missileLauncher);
	}
}

