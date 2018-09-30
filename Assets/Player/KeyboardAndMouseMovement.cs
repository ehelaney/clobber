using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardAndMouseMovement : MonoBehaviour
{
	public Player player;

	public void Update()
	{
		player.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		player.RotateTurret(mousePosition);

		// Attack on mouse click
		if (Input.GetMouseButtonDown(1))
		{
			player.AttackWithSecondary(Vector2.zero);
		}

		if (Input.GetMouseButtonDown(0))
		{
			player.AttackWithPrimary(Vector2.zero);
		}
	}
}
