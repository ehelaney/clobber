using System.Collections;
using System.Collections.Generic;
using Panda;
using UnityEngine;

namespace EnemyAI
{
	public class RandomPatrol : ScriptBase
	{

		Vector3 destination = Vector3.zero;
		public GameObject target;
		public float upperRange = 4.0f;
		public float speed = 1.0f;
		// Use this for initialization
		void Start()
		{
			target = GameObject.FindWithTag("Player");
		}

		/*
		* Used the a random position as destination and succeeds.
		*/
		[Task]
		bool SetDestination_Random()
		{
			destination = Random.insideUnitSphere * Random.Range(1f, upperRange);
			destination.z = 0.0f;

			return true;
		}

		/*
			* Move to the destination at the current speed and succeeds when the destination has been reached.
			*/
		[Task]
		void MoveToDestination()
		{
			var task = Task.current;
			var delta = destination - transform.position;

			bool success = false;
			if (transform.position != destination)
			{
				rb2d.velocity = delta.normalized * speed;

				// Check for overshooting the destination.
				// Succeed when the destination is reached.
				if (Vector3.Distance(destination, transform.position) < 0.1f)
				{
					success = true;
				}
			}

			if (transform.position == destination || success)
				task.Succeed();
		}
	}
}
