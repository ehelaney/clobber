using System.Collections;
using System.Collections.Generic;
using Panda;
using UnityEngine;

public class Flee : MonoBehaviour 
{
	public GameObject target;
	Vector3 destination = Vector3.zero;
	public float upperRange = 4.0f;

	public float speed = 1.0f;
	// Use this for initialization
	void Start () 
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

		if (transform.position != destination)
		{
			var velocity = delta.normalized * speed;
			transform.position = transform.position + velocity * Time.deltaTime;

			// Check for overshooting the destination.
			var newDelta = destination - transform.position;
			if (Vector3.Dot(newDelta, delta) < 0.0f)
			{
				transform.position = destination;
			}
		}

		if (transform.position == destination)
		{
			task.Succeed();
		}
	}
}
