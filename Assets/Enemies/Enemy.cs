using System;
using Panda;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PandaBehaviour))]
public class Enemy : MonoBehaviour
{
	public EnemyTypeDefinition TypeDefinition { get; set; }

	private int CurrentHealth { get; set; }
	private int _health;
	public int Health 
	{ 
		get{ return _health;} 
		set
		{
			_health = value;
			CurrentHealth = value;
		}
	}

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
	
		GetComponent<PandaBehaviour>().scripts = typeDef.aiType.behaviorTree;
		GetComponent<PandaBehaviour>().Apply();
	}

	public void Hit(int damage, Vector2 damageSource)
	{
		CurrentHealth -= damage;

		Vector2 recoil = ((Vector2)transform.position - damageSource).normalized * 0.25f;
		rb2d.MovePosition((Vector2)transform.position + recoil);

		EnemyFactory.Instance.HitSystem.OnEnemyHit(TypeDefinition, damageSource);

		if (CurrentHealth <= 0) Kill();
	}

	public void Kill()
	{
		EnemyFactory.Instance.OnEnemyDeath(TypeDefinition, transform.position);

		gameObject.SetActive(false);
	}

	[Task]
	public void LowHealth()
	{
		int percentHealthRemain = (int)((double)CurrentHealth / Health * 100);
		Task.current.Complete( percentHealthRemain <= 25 );
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			PlayerInfo.Instance.ChangeHealth(CollisionStrength * -1);
		}
	}
}
