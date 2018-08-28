using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{

	public EnemyTypeDefinition TypeDefinition { get; set; }

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Initialize(EnemyTypeDefinition typeDef, Vector2 pos)
	{
		TypeDefinition = typeDef;
		transform.position = pos;

		GetComponent<SpriteRenderer>().sprite = typeDef.Sprite;
	}

	public void Kill()
	{
		FindObjectOfType<EnemyDeathSystem>().OnEnemyDeath(TypeDefinition, transform.position);
		gameObject.SetActive(false);
	}
}
