using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyAI
{
	public class NormalPatrol : MonoBehaviour
	{
		public float moveSpeed = 4.0f;
		public float rotateSpeed = 360.0f;
		public float distanceToTravel = 5.0f;
		public float timeToPause = 0.25f;
		
		void Start () 
		{
			StartCoroutine(Execute());
		}
		public IEnumerator Execute()
		{
			while (true)
			{
				float distance = distanceToTravel;
				//move in straight line for distance specified
				while (distance > 0.0f)
				{
					float moveRate = moveSpeed * Time.deltaTime;
					//try not to overshoot the distance
					//TODO - find a better way?
					moveRate = Math.Min(moveRate, distance);

					transform.position += transform.up * moveRate;
					distance -= moveRate;

					yield return null;
				}

				//pause at end of movement for time specified
				yield return new WaitForSeconds(timeToPause);

				//for standard patrol, just have them turn around
				//I suppose we could open this up for more interesting movement
				float rotation = 180.0f;
				//turn around at specified pace
				while (rotation > 0.0f)
				{
					float spinRate = rotateSpeed * Time.deltaTime;
					//try not to overshoot the angle
					//TODO - find a better way?
					spinRate = Math.Min(spinRate, rotation);

					transform.Rotate(Vector3.forward * spinRate);
					rotation -= spinRate;

					yield return null;
				}
			}
		}
	}
}
