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

	public int CurrentRoomNumber()
	{
		return roomIndex + 1;
	}

	public void GoToFirstRoom()
	{
		roomIndex = 0;
		LoadCurrentRoom();
	}

	public void GoToNextRoom()
	{
		roomIndex++;
		Stats.Instance.RoomsCompletedlIncrementByOne();
		LoadCurrentRoom();
	}

	public void GoToGameOver()
	{
		//this method has no knowledge of whether this is game over success or failure so incrementing room count in gameover canvas instead
		GameSceneController.Instance.ChangeScene(gameOver);
	}

	private void LoadCurrentRoom()
	{
		Debug.Log("Load Current Room");
		if (roomIndex < roomSequence.Length)
		{
			Debug.Log("Loading Current Room");
			GameSceneController.Instance.ChangeScene(CurrentRoom);
		}
		else
		{
			GoToGameOver();
		}
	}
}
