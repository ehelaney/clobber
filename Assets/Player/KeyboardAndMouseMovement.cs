using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndMouseMovement : MonoBehaviour
{
	private Rigidbody2D rb;

	public float moveSpeed = 5.0f;

	public Player player;

	// Use this for initialization
	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//drop the z coord from the mouse position.  in a 2D game we can't determine depth, so use the same depth as the transform
		transform.right = new Vector3(mousePosition.x, mousePosition.y, transform.position.z) - transform.position;

		// Attack on mouse click
		if (Input.GetMouseButtonDown(1))
		{
			player.AttackWithMelee(Vector2.zero);
		}

		if (Input.GetMouseButtonDown(0))
		{
			player.AttackWithProjectile(Vector2.zero);
		}
	}
}
