using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
	[RequireComponent(typeof(Rigidbody2D))]
	public class ScriptBase : MonoBehaviour 
	{
		protected Rigidbody2D rb2d;

		private void Awake()
		{
			rb2d = GetComponent<Rigidbody2D>();
		}
	}
}
