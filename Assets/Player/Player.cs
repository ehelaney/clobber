using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
	public PlayerMovement playerMovement = PlayerMovement.KeyboardAndMouse;

	public RightHand rightHand;
	public LeftHand leftHand;

	private void Awake()
	{
		switch (playerMovement)
		{
			case PlayerMovement.KeyboardAndMouse:
				gameObject.AddComponent<KeyboardAndMouseMovement>().player = this;
				break;
			case PlayerMovement.TwinStick:
				gameObject.AddComponent<TwinStickMovement>().player = this;
				break;
			case PlayerMovement.SingleStickMoveAndFace:
				gameObject.AddComponent<SingleStickMoveAndFace>().player = this;
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

	public void AttackWithProjectile(Vector2 pos)
	{
		leftHand.Attack();
	}

	public void AttackWithMelee(Vector2 pos)
	{
		rightHand.Attack();
	}
	
}

public enum PlayerMovement
{
	TwinStick,
	KeyboardAndMouse,
	SingleStickMoveAndFace
}
