using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour , ICanBeHitByProjectile
{
	public PlayerMovement playerMovement = PlayerMovement.KeyboardAndMouse;

	public ProjectileWeapon projectileWeapon;
	public SoundDefinition playerHitSound;

	public Transform turret;

	public float moveSpeed = 5.0f;
	private Rigidbody2D rb;

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

	private void Start()
	{
		projectileWeapon.SetWeaponDefinition(PlayerInfo.Instance.CurrentProjectileWeapon);
		rb = GetComponent<Rigidbody2D>();
	}

	public void OnPlayerProjectileWeaponChanged(UnityEngine.Object weapon)
	{
		ProjectileWeaponDefinition weaponDef = (ProjectileWeaponDefinition)weapon;
		projectileWeapon.SetWeaponDefinition(weaponDef);
	}

	public void AttackWithPrimary(Vector2 pos)
	{
		projectileWeapon.OnFire();
	}

	public void AttackWithSecondary(Vector2 pos)
	{
		Debug.Log("No Secondary Weapon Exists");
	}

	public void Hit(int damage, Vector2 damageSource)
	{
		PlayerInfo.Instance.ChangeHealth(damage * -1);
		SoundManager.Instance.PlaySound(playerHitSound, this.gameObject.transform.position);
	}

	public void RotateTurret(Vector3 direction)
	{
		//drop the z coord from the mouse position.  in a 2D game we can't determine depth, so use the same depth as the transform
		turret.up = new Vector3(direction.x, direction.y, turret.position.z) - turret.position;
	}

	public void Move(Vector2 moveDirection)
	{
		rb.velocity = moveDirection * moveSpeed;

		leftJet.SetPower(moveDirection.x);
		rightJet.SetPower(moveDirection.x * -1);
		topJet.SetPower(moveDirection.y * -1);
		bottomJet.SetPower(moveDirection.y);
	}

	void ICanBeHitByProjectile.OnHitByProjectile(int damage, Vector2 location)
	{
		Hit(damage, location);
	}

	#region Jets

	public Jet leftJet;
	public Jet rightJet;
	public Jet topJet;
	public Jet bottomJet;

	#endregion Jets
}

public enum PlayerMovement
{
	TwinStick,
	KeyboardAndMouse,
	SingleStickMoveAndFace
}
