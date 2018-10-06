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
			Failure.gameObject.SetActive(false);
		}

		roomText.text = "You made it to Room " + RoomSelector.Instance.CurrentRoomNumber();
		pointsText.text = "Points: " + PlayerInfo.Instance.TotalPoints;
	}
}
