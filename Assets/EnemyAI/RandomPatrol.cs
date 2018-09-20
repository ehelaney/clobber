using System.Collections;
using System.Collections.Generic;
using Panda;
using UnityEngine;

public class RandomPatrol : MonoBehaviour 
{

	Vector3 destination = Vector3.zero;
	public GameObject target;
	public float upperRange = 4.0f;
	public float speed = 1.0f;
	// Use this for initialization
	void Start () 
	{
		Debug.Log("Start RandomPatrol");
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

		if (transform.position != destination)
		{
			var velocity = delta.normalized * speed;
			transform.position = transform.position + velocity * Time.deltaTime;

			// Check for overshooting the destination.
			// Succeed when the destination is reached.
			var newDelta = destination - transform.position;
			if (Vector3.Dot(newDelta, delta) < 0.0f)
			{
				transform.position = destination;
			}
		}

		if (transform.position == destination)
			task.Succeed();
	}
}
