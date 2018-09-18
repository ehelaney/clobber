using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector : Singleton<RoomSelector>
{
	private int roomIndex = -1;
	public GameScene[] roomSequence;
	public GameScene gameOver;

	public GameScene CurrentRoom
	{
		get
		{
			return roomSequence[roomIndex];
		}
	}

	public void GoToFirstRoom()
	{
		roomIndex = 0;
		LoadCurrentRoom();
		SoundManager.Instance.PlaySongByName("RoomSong1");
	}

	public void GoToNextRoom()
	{
		roomIndex++;
		LoadCurrentRoom();
	}

	public void GoToGameOver()
	{
		GameSceneController.Instance.ChangeScene(gameOver);
		SoundManager.Instance.PlaySongByName("GameOver");
	}

	private void LoadCurrentRoom()
	{
		if (roomIndex < roomSequence.Length)
		{
			GameSceneController.Instance.ChangeScene(CurrentRoom);
		}
		else
		{
			GoToGameOver();
		}
	}
}
