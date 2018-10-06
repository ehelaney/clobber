using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMenu : MonoBehaviour 
{
	public GameScene creditsScene;
	public GameEventInt startGameEvent;
	public SoundDefinition titleSong;

	void Start()
	{
		SoundManager.Instance.PlayMusic(titleSong);
	}

	public void OnGoToGame()
	{
		startGameEvent.Raise();
	}

	public void OnStatsClicked()
	{
		Stats.Instance.StatScreenVisitsIncrement();
		Stats.Instance.PersistStats(); //this seems kinda dumb but otherwise this won't get saved if you quit the game without hitting the game over screen
	}

	public void OnGoToCredits()
	{
		GameSceneController.Instance.ChangeScene(creditsScene);
	}

	public void OnQuitGame()
	{
		Debug.Log("Quit Button Pressed!");
		Application.Quit();
	}
}
