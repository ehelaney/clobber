using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

	public void Kill()
	{
		FindObjectOfType<EnemyDeathSystem>().OnEnemyDeath(TypeDefinition, transform.position);
		gameObject.SetActive(false);
	}
}
