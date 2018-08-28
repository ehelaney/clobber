using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
	public PlayerMovement playerMovement = PlayerMovement.KeyboardAndMouse;

	public GameObject rightHand;
	public GameObject rightEquip;
	private void Awake()
	{
		switch (playerMovement)
		{
			case PlayerMovement.KeyboardAndMouse:
				gameObject.AddComponent<KeyboardAndMouseMovement>();
				break;
			case PlayerMovement.TwinStick:
				gameObject.AddComponent<TwinStickMovement>();
				break;
			case PlayerMovement.SingleStickMoveAndFace:
				gameObject.AddComponent<SingleStickMoveAndFace>();
				break;
		}
	}

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	
}

public enum PlayerMovement
{
	TwinStick,
	KeyboardAndMouse,
	SingleStickMoveAndFace
}
