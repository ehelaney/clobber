using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate IEnumerable<Vector2> OnFire(Vector2 direction);

[Serializable]
public class ProjectileWeaponTypeDef
{
	public GameObject WeaponPrefab;
	public ProjectileType ProjectileType;
	public float RateOfFire; //how fast the "gun" shoots 
}

public enum ProjectileWeaponType
{
	BasicGun
}