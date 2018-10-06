using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : ScriptableSingleton<Stats>
{
	//NOTE - all stats are local, these are not public leaderboard stats

	//high score
	private int highScore;
	public int HighScore { get { return highScore; } }
	private void HighScoreIncrement()
	{
		if(PlayerInfo.Instance.TotalPoints > highScore)
		{
			highScore = PlayerInfo.Instance.TotalPoints;
			PlayerPrefs.SetInt("highScore", highScore);
		}
	}

	//total points from all playthroughs
	private int lifetimePoints;
	public int LifetimePoints { get { return lifetimePoints; } }
	private void LifetimePointsIncrement()
	{
		lifetimePoints += PlayerInfo.Instance.TotalPoints;
		PlayerPrefs.SetInt("lifetimePoints", lifetimePoints);
	}

	//total enemies killed
	private int enemiesKilled;
	public int EnemiesKilled { get { return enemiesKilled; } }
	public void EnemiesKilledIncrementByOne()
	{
		enemiesKilled += 1;
		PlayerPrefs.SetInt("enemiesKilled", enemiesKilled);
	}

	//total rooms completed
	private int roomsCompleted;
	public int RoomsCompleted { get { return roomsCompleted; } }
	public void RoomsCompletedlIncrementByOne()
	{
		roomsCompleted += 1;
		PlayerPrefs.SetInt("roomsCompleted", roomsCompleted);
	}
	
	//total damage taken
	private int damageTakenTotal;
	public int DamageTakenTotal { get { return damageTakenTotal; } }
	public void DamageTakenTotalIncrement(int damage)
	{
		damageTakenTotal += damage;
		PlayerPrefs.SetInt("damageTakenTotal", damageTakenTotal);
	}

	//number of times visited stat screen
	private int statScreenVisits;
	public int StatScreenVisits { get { return statScreenVisits; } }
	public void StatScreenVisitsIncrement()
	{
		statScreenVisits += 1;
		PlayerPrefs.SetInt("statScreenVisits", statScreenVisits);
	}

	private bool statsLoaded;

	//We could shift some other areas of the game to load all playerprefs here, such as sound settings.  If so "Stats" is a bad name. 
	public void LoadPlayerPrefs()
	{
		if(!statsLoaded)
		{ 
			//no default values set anywhere else for these so set default values if the key doesnt exist
			highScore = PlayerPrefs.GetInt("highScore", 0);
			lifetimePoints = PlayerPrefs.GetInt("lifetimePoints", 0);
			enemiesKilled = PlayerPrefs.GetInt("enemiesKilled", 0);
			roomsCompleted = PlayerPrefs.GetInt("roomsCompleted", 0);
			damageTakenTotal = PlayerPrefs.GetInt("damageTakenTotal", 0);
			statScreenVisits = PlayerPrefs.GetInt("statScreenVisits", 0);
		}
		statsLoaded = true;
	}

	//store all stats (probably only call from game over so we dont store stats for incomplete playthroughs (if you ragequit and close the browser)
	public void PersistStats()
	{
		//these methods are only incremented based on the values tracked in PlayerInfo
		HighScoreIncrement();
		LifetimePointsIncrement();

		PlayerPrefs.Save();
	}

}
