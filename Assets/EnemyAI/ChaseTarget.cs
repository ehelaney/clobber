using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
	public class ChaseTarget : ScriptBase
	{
		public float moveSpeed = 2.0f;
		public float rotateSpeed = 60.0f;

		public float visualAcuity = 3.0f;
		public Transform target;
		
		void Start () 
		{
			Debug.Log("Start ChaseTarget");
			target = GameObject.FindWithTag("Player").transform;
			StartCoroutine(Execute());
		}
		public IEnumerator Execute()
		{
			while (true)
			{
				if (target != null) 
				{
					float distanceToTarget = Vector2.Distance (transform.position, target.transform.position);
         			if (distanceToTarget <= visualAcuity) 
					{
						Vector3 directionToTarget = target.position - transform.position;
						//somehow screwed up some enemies and they were above the player...so do this for now???
						directionToTarget.z = 0f;

						float spinRate = rotateSpeed * Time.deltaTime;
						//look at player first
						if (directionToTarget != Vector3.zero)
						{
							transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.FromToRotation (Vector3.right, directionToTarget), spinRate);
						}
						//now move towards target
						float moveRate = moveSpeed * Time.deltaTime;
						transform.position += (target.position - transform.position).normalized * moveRate;
					}
				}
				yield return null;
			}
		}

    }
}
