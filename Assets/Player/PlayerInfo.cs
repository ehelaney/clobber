using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : Singleton<PlayerInfo>
{
	[Range(1, 10)]
	public int maxHealth = 7;

	private int health;
	public int Health { get { return health; } }

	/// <summary>
	/// Total points the player has accumulated
	/// </summary>
	private int totalPoints;
	public int TotalPoints { get { return totalPoints; } }

	public void StartGame()
	{
		health = maxHealth;
		totalPoints = 0;
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
			//Also TODO: the PlayerInfo shouldn't be transitioning states.  This logic should move to the room/scene transition system once that is created

			RoomSelector.Instance.GoToGameOver();
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
		Debug.Log("Total points: " + TotalPoints); // Temporary until we have a UI displaying points
	}

	#endregion Points
}
