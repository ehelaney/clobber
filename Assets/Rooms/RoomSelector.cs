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
	}

	public void GoToNextRoom()
	{
		roomIndex++;
		LoadCurrentRoom();
	}
	
	private void LoadCurrentRoom()
	{
		if (roomIndex < roomSequence.Length)
		{
			GameSceneController.Instance.ChangeScene(CurrentRoom);
		}
		else
		{
			GameSceneController.Instance.ChangeScene(gameOver);
		}
	}
}
