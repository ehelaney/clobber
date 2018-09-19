using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSelector : ScriptableSingleton<RoomSelector>
{
	private int roomIndex = -1;
	public GameScene[] roomSequence;
	public GameScene gameOver;

	public GameEventListenerScriptableObjectInt[] listeners;

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

	public void GoToGameOver()
	{
		GameSceneController.Instance.ChangeScene(gameOver);
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
