﻿using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EnemyKilledEvent : UnityEvent<int> { }

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
	public EnemyTypeDefinition TypeDefinition { get; set; }

	public int Health { get; set; }

	public EnemyKilledEvent EnemyKilled;

	/// <summary>
	/// The amount of damage the enemy will do to the player upon colliding
	/// </summary>
	public int CollisionStrength = 1;

	private Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	public void Initialize(EnemyTypeDefinition typeDef, Vector2 pos)
	{
		TypeDefinition = typeDef;
		transform.position = pos;

		GetComponent<SpriteRenderer>().sprite = typeDef.Sprite;
		Health = TypeDefinition.Health;
	}

	public void Hit(int damage, Vector2 damageSource)
	{
		Health -= damage;

		Vector2 recoil = ((Vector2)transform.position - damageSource).normalized * 0.25f;
		rb2d.MovePosition((Vector2)transform.position + recoil);

		EnemyFactory.Instance.HitSystem.OnEnemyHit(TypeDefinition, damageSource);

		if (Health <= 0) Kill();
	}

	public void Kill()
	{
		EnemyFactory.Instance.DeathSystem.OnEnemyDeath(TypeDefinition, transform.position);
		if(EnemyKilled != null)
		{
			EnemyKilled.Invoke(TypeDefinition.PointsForKilling);
		}

		gameObject.SetActive(false);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerInfo.Instance.ChangeHealth(CollisionStrength * -1);
		}
	}
}
