using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Player : MonoBehaviour
{
	[Range(1, 10)]
	public int maxHealth = 7;

	private int health;
	public int Health { get { return health; } }

	/// <summary>
	/// Total points the player has accumulated
	/// </summary>
	public int TotalPoints;

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
		SetHealth(maxHealth);
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

	/// <summary>
	/// Called when an enemy is killed.  This is invoked from the Enemy base class using UnityEvents
	/// </summary>
	/// <param name="enemyPoints"></param>
	public void OnEnemyKilled(int enemyPoints)
	{
		TotalPoints += enemyPoints;
		Debug.Log("Total points: " + TotalPoints); // Temporary until we have a UI displaying points
	}

	#region Health

	public delegate void HealthChanged(int newHealth);
	public HealthChanged OnHealthChanged;

	public void ChangeHealth(int diff)
	{
		SetHealth(health + diff);
	}

	private void SetHealth(int h)
	{
		health = h;
		health = Mathf.Min(health, maxHealth);
		if (OnHealthChanged != null)
		{
			OnHealthChanged(health);
		}

		if (health <= 0)
		{
			//TODO: do something because the player died (before it transitions to the final scene)
			FindObjectOfType<GameStateEngine>().ChangeGameState(GameStates.GameOver);
		}
	}

	#endregion
}

public enum PlayerMovement
{
	TwinStick,
	KeyboardAndMouse,
	SingleStickMoveAndFace
}
