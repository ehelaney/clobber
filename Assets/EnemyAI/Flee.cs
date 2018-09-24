using System.Collections;
using System.Collections.Generic;
using Panda;
using UnityEngine;

namespace EnemyAI
{
	public class Flee : ScriptBase
	{
		public GameObject target;
		Vector3 destination = Vector3.zero;
		public float upperRange = 4.0f;

		public float speed = 1.0f;
		// Use this for initialization
		void Start()
		{
			target = GameObject.FindWithTag("Player");
		}

		[Task]
		bool SetSafeDestination()
		{
			Vector3 playerDirection = (target.transform.position - this.transform.position).normalized;
			//probably not really what we want, but it is close enough
			destination = playerDirection * -1f;
			destination.z = 0.0f;
			return true;
		}

		[Task]
		void RunAway()
		{
			var task = Task.current;
			var delta = destination - transform.position;

			bool success = false;
			if (transform.position != destination)
			{
				rb2d.velocity = delta.normalized * speed;

				// Check for overshooting the destination.
				if (Vector3.Distance(destination, transform.position) < 0.1f)
				{
					success = true;
				}
			}

			if (transform.position == destination || success)
			{
				task.Succeed();
			}
		}
	}
}
