using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrimaryWeapon : MonoBehaviour
{
	public ProjectileWeapon projectileWeapon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Attack()
	{
		projectileWeapon.OnFire();
	}
}
