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

	public void Initialize(ProjectileTypeDef typeDef, Vector2 startingPoint, Vector2 direction, Quaternion rotation)
	{
		TypeDefinition = typeDef;
		gameObject.transform.position = startingPoint;
		gameObject.transform.rotation = rotation;
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
}
