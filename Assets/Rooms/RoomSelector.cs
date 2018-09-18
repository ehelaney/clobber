using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector : Singleton<RoomSelector>
{
	private int roomIndex = -1;
	public GameScene[] roomSequence;
	public GameScene gameOver;
	public SoundDefinition gameOverSong;
	public SoundDefinition roomSong1; //turn this into an array if we want to randomize songs per room or per playthrough

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
		SoundManager.Instance.PlayMusic(roomSong1);
	}

	public void GoToNextRoom()
	{
		roomIndex++;
		LoadCurrentRoom();
	}

	public void GoToGameOver()
	{
		GameSceneController.Instance.ChangeScene(gameOver);
		SoundManager.Instance.PlayMusic(gameOverSong);
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
