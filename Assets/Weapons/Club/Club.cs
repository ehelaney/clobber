using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Club : MonoBehaviour, IWeapon
{
	private Vector3 localPos;

	public bool WeaponActive { get; set; }

	//hard-coding this here, but probably want to pull it out into data
	public int Damage = 1;

	// Use this for initialization
	void Start () 
	{
		// Cache the current location relative to the parent
		localPos = transform.localPosition;
		WeaponActive = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Set location relative to parent
		transform.position = transform.parent.position;
		transform.localPosition = localPos;
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
			other.gameObject.GetComponent<Enemy>().Hit(Damage, (transform.position + other.transform.position) / 2f);
		}
	}
}
