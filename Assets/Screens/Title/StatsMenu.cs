using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsMenu : MonoBehaviour
{
	public Text HighScore;
	public Text LifetimePoints;
	public Text EnemiesKilled;
	public Text DamageTokenTotal;
	public Text RoomsCompleted;
	public Text StatScreenVisits;

	private void Awake()
	{
		Debug.Log("Stats Menu Awake is called");
		Stats.Instance.LoadPlayerPrefs();
	}

	private void Start()
	{
		gameObject.SetActive(false);
	}


	//should be called when you navigate to the stats menu
	private void OnEnable()
	{
		HighScore.text = "High Score: " + Stats.Instance.HighScore;
		LifetimePoints.text = "Lifetime Points: " + Stats.Instance.LifetimePoints;
		EnemiesKilled.text = "Enemies Killed: " + Stats.Instance.EnemiesKilled;
		DamageTokenTotal.text = "Damage Taken: " + Stats.Instance.DamageTakenTotal;
		RoomsCompleted.text = "Rooms Completed: " + Stats.Instance.RoomsCompleted;
		StatScreenVisits.text = "Viewed Statistics:  " + Stats.Instance.StatScreenVisits;
	}


}
