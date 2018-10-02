using System;
using Panda;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PandaBehaviour))]
public class Enemy : MonoBehaviour, ICanBeHitByProjectile
{
	public SpriteRenderer spriteRenderer;

	public EnemyTypeDefinition TypeDefinition { get; set; }

	public ProjectileWeapon projectileWeapon;

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

	private bool rapidFireShooting = false;

	// Use this for initialization
	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		if (rapidFireShooting)
		{
			Attack();
		}
	}

	public void Initialize(EnemyTypeDefinition typeDef, Vector2 pos)
	{
		TypeDefinition = typeDef;
		transform.position = pos;

		spriteRenderer.sprite = typeDef.Sprite;
		Health = TypeDefinition.Health;

		var panda = GetComponent<PandaBehaviour>();
		panda.scripts = typeDef.aiType.behaviorTree;
		panda.Apply();
		panda.Compile();

		projectileWeapon.SetWeaponDefinition(typeDef.weapon);
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
			collision.gameObject.GetComponent<Player>().Hit(CollisionStrength, (transform.position + collision.gameObject.transform.position) / 2f);
			Hit(CollisionStrength, collision.relativeVelocity);
		}
	}

	[Task]
	public bool Attack()
	{
		projectileWeapon.OnFire();
		return true;
	}

	[Task]
	public bool StartShootingAtGunRate()
	{
		rapidFireShooting = true;
		return true;
	}

	[Task]
	public bool StopShootingAtGunRate()
	{
		rapidFireShooting = false;
		return true;
	}

	void ICanBeHitByProjectile.OnHitByProjectile(int damage, Vector2 location)
	{
		Hit(damage, location);
	}
}
