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
			float spinRate = rotateSpeed * Time.deltaTime;
			rb2d.MoveRotation(rb2d.rotation + spinRate);
			rb2d.velocity = moveSpeed * transform.up;
		}
	}
}
