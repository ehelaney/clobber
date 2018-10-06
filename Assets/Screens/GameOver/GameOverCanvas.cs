using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverCanvas : MonoBehaviour
{
	public GameScene titleScene;
	public SoundDefinition gameOverSong;
	public Text roomText;
	public Text pointsText;
	public Text highScoreText;
	public Canvas Success;
	public Canvas Failure;


	public void OnBackToStart()
	{
		GameSceneController.Instance.ChangeScene(titleScene);
	}

	private void Start()
	{
		SoundManager.Instance.PlayMusic(gameOverSong);

		//if player is dead, failure, otherwise success
		if(PlayerInfo.Instance.PlayerIsDead)
		{
			Success.gameObject.SetActive(false);
		}
		else //success
		{
			Stats.Instance.RoomsCompletedlIncrementByOne(); //GoToGameOver has no knowledge of whether this is game over success or failure so incrementing room count here instead.  Not ideal
			Failure.gameObject.SetActive(false);
		}

		Stats.Instance.PersistStats();
		roomText.text = "You made it to Room " + RoomSelector.Instance.CurrentRoomNumber();
		pointsText.text = "Points: " + PlayerInfo.Instance.TotalPoints;
		highScoreText.text = "High Score: " + Stats.Instance.HighScore;
	}
}
