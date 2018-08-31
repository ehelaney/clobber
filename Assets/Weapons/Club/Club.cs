using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour, IWeapon
{
	public bool WeaponActive { get; set; }

	// Use this for initialization
	void Start () 
	{
		WeaponActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (WeaponActive && other.gameObject.CompareTag("Enemy"))
		{
			other.gameObject.GetComponent<Enemy>().Kill();
		}
	}
}
