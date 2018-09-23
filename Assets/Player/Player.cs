using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
	public PlayerMovement playerMovement = PlayerMovement.KeyboardAndMouse;

	public SecondaryWeapon secondaryWeapon;
	public PrimaryWeapon primaryWeapon;

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

	public void AttackWithPrimary(Vector2 pos)
	{
		primaryWeapon.Attack();
	}

	public void AttackWithSecondary(Vector2 pos)
	{
		secondaryWeapon.Attack();
	}
}

public enum PlayerMovement
{
	TwinStick,
	KeyboardAndMouse,
	SingleStickMoveAndFace
}
