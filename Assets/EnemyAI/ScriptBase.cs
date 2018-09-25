using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
	[RequireComponent(typeof(Enemy))]
	[RequireComponent(typeof(Rigidbody2D))]
	public class ScriptBase : MonoBehaviour 
	{
		protected Rigidbody2D rb2d;
		protected EnemyAIType typeDefinition;
		protected GameObject thePlayer;

		private void Awake()
		{
			rb2d = GetComponent<Rigidbody2D>();
		}

		private void Start()
		{
			typeDefinition = GetComponent<Enemy>().TypeDefinition.aiType;
			thePlayer = GameObject.FindWithTag("Player");
		}
	}
}
