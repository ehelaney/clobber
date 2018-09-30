using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : ScriptableSingleton<PlayerInfo>
{
	[Range(1, 10)]
	public int maxHealth = 7;

	public ProjectileWeaponDefinition startingProjectileWeapon;
	public MeleeWeaponDefinition startingMeleeWeapon;


	private int health;
	public int Health { get { return health; } }

	private bool playerIsDead;
	public bool PlayerIsDead { get { return playerIsDead; } }

	/// <summary>
	/// Total points the player has accumulated
	/// </summary>
	private int totalPoints;
	public int TotalPoints { get { return totalPoints; } }

	public GameEventListenerScriptableObjectInt scoredPointsListener; //this is necessary so the asset loads with the playerinfo
	public GameEventListenerScriptableObjectInt startGameListener;
	public GameEventInt pointsChanged;

	public void StartGame()
	{
		health = maxHealth;
		totalPoints = 0;
		playerIsDead = false;

		ChangeProjectileWeapon(startingProjectileWeapon);
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

			playerIsDead = true;
		}
	}

	#endregion

	#region Points

	/// <summary>
	/// Called when an enemy is killed.  This is invoked from the Enemy base class using UnityEvents
	/// </summary>
	/// <param name="enemyPoints"></param>
	public void OnEnemyKilled(int enemyPoints)
	{
		GainPoints(enemyPoints);
	}

	public void GainPoints(int points)
	{
		totalPoints += points;
		if (pointsChanged != null)
		{
			pointsChanged.Raise(totalPoints); 
		}
	}

	#endregion Points

	#region Weapons

	private ProjectileWeaponDefinition currentProjectileWeapon;
	public ProjectileWeaponDefinition CurrentProjectileWeapon { get { return currentProjectileWeapon; } }

	public GameEventUnityObject projectileWeaponChanged;

	public void ChangeProjectileWeapon(ProjectileWeaponDefinition weapon)
	{
		SetProjectileWeapon(weapon);
	}
	private void SetProjectileWeapon(ProjectileWeaponDefinition weapon)
	{
		currentProjectileWeapon = weapon;
		projectileWeaponChanged.Raise(currentProjectileWeapon);
	}
	#endregion
}
