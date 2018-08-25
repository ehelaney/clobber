using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStickMoveAndFace : MonoBehaviour
{
	private Rigidbody2D rb;

	public float moveSpeed = 5.0f;

	// Use this for initialization
	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	public void Update()
	{
		var direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		rb.velocity = direction * moveSpeed;
		transform.right = direction;
	}
}
