using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTestCanvas : MonoBehaviour
{
	public Player player;
	public ProjectileWeaponDefinition laserWeapon;

	public void EquipLaserWeapon()
	{
		player.EquipProjectileWeapon(laserWeapon);
	}

}

