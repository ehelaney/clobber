using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
	public GameScene titleScene;
	public SoundDefinition gameOverSong;

	public void OnBackToStart()
	{
		GameSceneController.Instance.ChangeScene(titleScene);
	}

	private void Start()
	{
		SoundManager.Instance.PlayMusic(gameOverSong);
	}
}
