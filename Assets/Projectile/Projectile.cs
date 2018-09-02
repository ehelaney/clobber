using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Projectile : MonoBehaviour
{
	public ProjectileTypeDef TypeDefinition
	{
		get;
		private set;
	}

	public int Damage { get; private set; }

	public void Initialize(ProjectileTypeDef typeDef, Vector2 startingPoint, Vector2 direction)
	{
		TypeDefinition = typeDef;
		gameObject.transform.position = startingPoint;
		GetComponent<Rigidbody2D>().AddForce(direction * typeDef.Speed, ForceMode2D.Impulse);
		Damage = TypeDefinition.Damage;
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void OnHitSomething()
	{
		gameObject.SetActive(false);
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			other.gameObject.GetComponent<Enemy>().Hit(Damage, (transform.position + other.transform.position) / 2f);
			OnHitSomething();
		}
	}
}

