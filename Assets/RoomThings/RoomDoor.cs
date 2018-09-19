using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomDoor : MonoBehaviour
{
	public GameEventInt nextRoomEvent;

	void Awake()
	{
		transform.position = new Vector2(Random.Range(-5f, 5f), Random.Range(-5f, 5f));
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			nextRoomEvent.Raise();
		}
	}
}
