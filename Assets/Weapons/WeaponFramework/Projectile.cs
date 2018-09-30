using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Projectile : MonoBehaviour
{
	public ProjectileDefinition TypeDefinition
	{
		get;
		private set;
	}

	public int Damage { get; private set; }

	public float SpeedBurstDuration;
	private bool awaitingSlowdown = false;
	private float speedBurstTimer = 0.0f;
	private Vector2 slowDownForce;

	public void Initialize(ProjectileDefinition projectileDefintion, Vector2 startingPoint, Vector2 direction, Quaternion rotation)
	{
		TypeDefinition = projectileDefintion;
		gameObject.transform.position = startingPoint;
		gameObject.transform.rotation = rotation;

		Damage = TypeDefinition.Damage;
		gameObject.layer = projectileDefintion.Layer;
		GetComponent<SpriteRenderer>().sprite = projectileDefintion.sprite;

		Vector2 projectileForce = direction * TypeDefinition.Speed;
		GetComponent<Rigidbody2D>().AddForce(projectileForce * 2.0f, ForceMode2D.Impulse);
		speedBurstTimer = SpeedBurstDuration;
		slowDownForce = projectileForce * -1;
		awaitingSlowdown = true;
	}

	private void Update()
	{
		if (awaitingSlowdown)
		{
			speedBurstTimer -= Time.deltaTime;
			if (speedBurstTimer <= 0.0f)
			{
				GetComponent<Rigidbody2D>().AddForce(slowDownForce, ForceMode2D.Impulse);
				awaitingSlowdown = false;
			}
		}
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
		var target = other.gameObject.GetComponent<ICanBeHitByProjectile>();
		if (target != null)
		{
			target.OnHitByProjectile(Damage, (transform.position + other.transform.position) / 2f);
		}
	}
}

public interface ICanBeHitByProjectile
{
	void OnHitByProjectile(int damage, Vector2 location);
}
