using System;
using System.Collections;
using System.Collections.Generic;
using Panda;
using UnityEngine;

namespace EnemyAI
{
	public class CirclePatrol : ScriptBase
	{
		public float moveSpeed = 2.5f;
		public float rotateSpeed = 90.0f;
		
		void Start () 
		{
			
		}
		[Task]
		public void ExecuteCirclePatrol()
		{
			float moveRate = moveSpeed * Time.deltaTime;

			float spinRate = rotateSpeed * Time.deltaTime;

			transform.Rotate(Vector3.forward * spinRate);

			transform.position += transform.up * moveRate;
		}
	}
}
