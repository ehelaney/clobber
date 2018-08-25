using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinStickMovement : MonoBehaviour
{
	private Rigidbody2D rb;

	public float moveSpeed = 5.0f;

	// Use this for initialization
	public void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	public void Update ()
	{
		rb.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
		transform.right = new Vector2(Input.GetAxis("RightHorizontal"), Input.GetAxis("RightVertical"));
	}
}
