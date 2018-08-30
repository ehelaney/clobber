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
	public ProjectileWeapon projectileWeapon; //added this to test projectiles, we probably won't keep it here, but I didnt want to wait until I integrated it with the other weapon code

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
