using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ProjectileTypeDef
{
	public GameObject ProjectilePrefab;
	public ProjectileType ProjectileType;
	//public ProjectileLayer Layer;
	public float Speed;
	public int Damage;
}

public enum ProjectileType
{
	Bullet
}

public enum ProjectileLayer
{
	//once we set up layers for player, enemies, maybe environment, put the enum here
}

